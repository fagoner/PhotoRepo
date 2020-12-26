using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PhotoRepo.Models
{

    public class Photo
    {
        public string Id => Object.ToString();

        [BsonId]
        public ObjectId Object { get; set; }

        [BsonElement("original_name")]
        public string Originalname { get; set; }

        [BsonElement("size")]
        public long Size { get; set; }

        [BsonElement("file_path")]
        public string FilePath { get; set; }

        [BsonElement("url_path")]
        public string UrlPath {get; set;}

        public override string ToString()
        {
            return $@"
            (
                'Id': {Id},
                'OriginalName': '{Originalname}',
                'Size': {Size},
                'FilePath': '{FilePath}',
                'UrlPath': '{UrlPath}'
            )";
        }
    }
    
}