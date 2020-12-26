using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PhotoRepo.Models;

namespace PhotoRepo.Handlers
{


    public interface IRepositoryHandler
    {
        Task<Photo> Save(IFormFile image);

        Task<long> Count();

        Task<ICollection<Photo>> GetAll();

        Task<Photo> GetById(string id);
    }



}