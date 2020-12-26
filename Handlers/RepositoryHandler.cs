using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PhotoRepo.Models;
using PhotoRepo.Repositories;

namespace PhotoRepo.Handlers
{
    public class RepositoryHandler : IRepositoryHandler
    {
        private IWebHostEnvironment _env;

        private IFileRepository _fileRepository;

        private IPhotoRepository _photoRepository;

        public RepositoryHandler(IWebHostEnvironment env, IFileRepository fileRepository, IPhotoRepository photoRepository)
        {
            _env = env;
            _fileRepository = fileRepository;
            _photoRepository = photoRepository;
        }

        public async Task<long> Count()
        {
            return await _photoRepository.Count();
        }

        public async Task<ICollection<Photo>> GetAll()
        {
            return await _photoRepository.GetAll();
        }

        public async Task<Photo> GetById(string id)
        {
            return await _photoRepository.GetById(id);
        }

        public async Task<Photo> Save(IFormFile image)
        {
            var photo = GeneratePhotoModel(image);

            //save to LocalRepo
            await _fileRepository.Save(photo.FilePath, image);

            //save to MongoRepo
            await _photoRepository.Save(photo);

            return photo;
        }

        private Photo GeneratePhotoModel(IFormFile image)
        {
            var urlPath = $"public/{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            var filePath = Path.Combine(_env.ContentRootPath, urlPath);

            return new Photo
            {
                FilePath = filePath,
                Originalname = image.FileName,
                Size = image.Length,
                UrlPath = urlPath
            };
        }
    }

}