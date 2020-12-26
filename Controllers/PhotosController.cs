using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace PhotoRepo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PhotosController : ControllerBase
    {

        private MongoClient _mongoClient;
        private IMongoDatabase _database;

        private IMongoCollection<BsonDocument> _photoCollection;

        private IWebHostEnvironment _env;

        public PhotosController(IWebHostEnvironment env)
        {
            _env = env;
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
        public async Task<IActionResult> OnPost(IFormFile file)
        {
            var fileSize = file.Length;

            var finalPath = Path.Combine(_env.ContentRootPath, $"public/{file.FileName}");

            // using (var stream = System.IO.File.Create(finalPath))
            // {
            //     await file.CopyToAsync(stream);
            // }
            //headers = file.Headers["Content-Type"].
            var content = 
                file.Headers.GetCommaSeparatedValues("Content-Type");
                
            return Accepted(new
            {
                fileSize = $"{fileSize} bytes",
                fileName = file.FileName,
                tempName = Path.GetTempFileName(),
                finalPath = finalPath,
                content = content
            });
        }

    }
}
