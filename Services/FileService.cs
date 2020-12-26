using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PhotoRepo.Services
{

    public class FileService : IFileService
    {

        private IWebHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> Save(IFormFile image)
        {
            var filePath = GenerateFilePath(image.FileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await image.CopyToAsync(stream);
            }

            return filePath;
        }

        private string GenerateFilePath(string fileName)
        {
            var publicPath = Path.Combine(_env.ContentRootPath, $"public");

            return $"{publicPath}/{Guid.NewGuid()}{Path.GetExtension(fileName)}";
        }
    }

}