using System;
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

        [BsonElement("emailAddress")]
        public string EmailAddress { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("company")]
        public string Company { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("photoUrl")]
        public string PhotoUrl { get; set; }

        [BsonElement("passwordHash")]
        public byte[] PasswordHash { get; set; }

        [BsonElement("passwordSalt")]
        public byte[] PasswordSalt { get; set; }

        [BsonElement("projects")]
        public List<Project> Projects { get; set; }

        [BsonElement("repositories")]
        public List<string> Repositories { get; set; }
    }

    public class Project
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }
    }
}