using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Data.Domain
{
    public class Student
    {
        [BsonElement("Id")]
        public Guid Id { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("MiddleName")]
        public string MiddleName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Phones")]
        public List<Phone> Phones { get; set; }
    }
}
