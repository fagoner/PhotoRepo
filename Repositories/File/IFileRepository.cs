using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PhotoRepo.Repositories
{

    public interface IFileRepository
    {
        Task Save(string filePath, IFormFile image);
    }

}