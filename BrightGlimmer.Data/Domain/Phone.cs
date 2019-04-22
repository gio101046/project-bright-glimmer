using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Data.Domain
{
    public class Phone
    {
        [BsonElement("Id")]
        public Guid Id { get; set; }
        [BsonElement("Type")]
        public PhoneType Type { get; set; }
        [BsonElement("AreaCode")]
        public int AreaCode { get; set; }
        [BsonElement("Number")]
        public int Number { get; set; }
    }
}
