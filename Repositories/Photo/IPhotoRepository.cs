using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PhotoRepo.Models;

namespace PhotoRepo.Repositories
{


    public interface IPhotoRepository
    {
        Task Save(Photo photo);
        Task<long> Count();

        Task<ICollection<Photo>> GetAll();

        Task<Photo> GetById(string id);
    }

}