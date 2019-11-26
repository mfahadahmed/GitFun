using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GitFun.API.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("repositories")]
        public IEnumerable<Repository> Repositories { get; set; }
        //public User[] Followers { get; set; }
    }

    public class Repository
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("isPublic")]
        public bool IsPublic { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }
    }
}