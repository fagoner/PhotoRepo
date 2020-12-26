using System.Collections.Generic;

namespace PhotoRepo.Models
{

    public class PhotoIndexResponse
    {

        public long Count { get; set; }

        public ICollection<Photo> Photos { get; set; }

    }
}