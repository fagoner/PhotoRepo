using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using PhotoRepo.Services;

namespace PhotoRepo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PhotosController : ControllerBase
    {

        private MongoClient _mongoClient;
        private IMongoDatabase _database;

        private IMongoCollection<BsonDocument> _photoCollection;

        private IFileService _fileService;

        public PhotosController(IFileService fileService)
        {
            _fileService = fileService;
            _mongoClient = new MongoClient("mongodb://root:example@localhost:27017");
            _database = _mongoClient.GetDatabase("photo_repo");
            _photoCollection = _database.GetCollection<BsonDocument>("photos");

        }

        [HttpGet]
        public ActionResult<dynamic> Index()
        {
            var count = _photoCollection.CountDocuments(new BsonDocument());
            return Ok(new { count = count });
        }

        [HttpPost]
        public async Task<IActionResult> OnPost(IFormFile image)
        {
            var newFile = await _fileService.Save(image);
            return Accepted(new { message = $"New File saved: {newFile}" });
        }

    }
}
