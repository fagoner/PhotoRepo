using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PhotoRepo.Services
{

    public interface IFileService
    {

        Task<string> Save(IFormFile image);

    }

}