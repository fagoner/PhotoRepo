using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using PhotoRepo.Models;

namespace PhotoRepo.Repositories
{


    public class PhotoRepository : IPhotoRepository
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _database;

        private IMongoCollection<Photo> _photoCollection;

        public PhotoRepository()
        {
            _mongoClient = new MongoClient("mongodb://root:example@localhost:27017");
            _database = _mongoClient.GetDatabase("photo_repo");
            _photoCollection = _database.GetCollection<Photo>("photos");
        }

        public async Task<long> Count()
        {
            var size = await _photoCollection.CountDocumentsAsync<Photo>(x => x.Id != null);
            return size;
        }

        public async Task<ICollection<Photo>> GetAll()
        {
            var filter = new BsonDocument();
            var result = await _photoCollection.Find(filter)
                    .ToListAsync<Photo>();
            return result;
        }

        public async Task<Photo> GetById(string id)
        {
            var filter = new BsonDocument();
            var result = await _photoCollection.FindAsync(p => p.Id == id);
            return result.FirstOrDefault();
        }

        public async Task Save(Photo photo)
        {
            await _photoCollection.InsertOneAsync(photo);
        }
    }

}