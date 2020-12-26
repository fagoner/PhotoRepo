using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PhotoRepo.Repositories
{


    public class FileRepository : IFileRepository
    {
        public async Task Save(string filePath, IFormFile image)
        {
            using (var stream = System.IO.File.Create(filePath))
            {
                await image.CopyToAsync(stream);
            }
        }
    }

}