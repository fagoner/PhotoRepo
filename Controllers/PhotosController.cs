using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoRepo.Models;
using PhotoRepo.Handlers;
using System.Linq;

namespace PhotoRepo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PhotosController : ControllerBase
    {

        private IRepositoryHandler _repositoryHandler;

        public PhotosController(IRepositoryHandler repositoryHandler)
        {
            _repositoryHandler = repositoryHandler;
        }

        [HttpGet]
        public async Task<ActionResult<PhotoIndexResponse>> Index()
        {
            var photosResult = await _repositoryHandler.GetAll();

            var result = new PhotoIndexResponse
            {
                Count = photosResult.Count(),
                Photos = photosResult
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Photo>> OnPost(IFormFile image)
        {
            var photo = await _repositoryHandler.Save(image);
            return Accepted(photo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Photo>> GetById(string id)
        {
            var result = await _repositoryHandler.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
