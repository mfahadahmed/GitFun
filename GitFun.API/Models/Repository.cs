using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace GitFun.API.Models
{
    public class Repository
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }

        [BsonElement("branches")]
        public List<string> Branches { get; set; }

        [BsonElement("commits")]
        public List<string> Commits { get; set; }

        [BsonElement("isPublic")]
        public bool IsPublic { get; set; }

        [BsonElement("isStarred")]
        public bool IsStarred { get; set; }

        [BsonElement("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [BsonElement("owner")]
        public string Owner { get; set; }
    }
}
