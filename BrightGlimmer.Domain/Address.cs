using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BrightGlimmer.Domain
{
    [Table("Addresses")]
    public class Address : Entity
    {
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }
        [JsonIgnore]
        public decimal Latitude { get; private set; }
        [JsonIgnore]
        public decimal Longitude { get; private set; }

        private Address() { }

        public Address(string streetAddress1,
                       string streetAddress2,
                       string city,
                       string stateCode,
                       string county,
                       string zipCode)
        {
            StreetAddress1 = streetAddress1;
            StreetAddress2 = streetAddress2;
            City = city;
            StateCode = stateCode;
            County = county;
            ZipCode = zipCode;
        }

        public Address(string streetAddress1,
                       string streetAddress2,
                       string city,
                       string stateCode,
                       string county,
                       string zipCode,
                       decimal latitude,
                       decimal longitude)
        {
            StreetAddress1 = streetAddress1;
            StreetAddress2 = streetAddress2;
            City = city;
            StateCode = stateCode;
            County = county;
            ZipCode = zipCode;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void Update(Address address)
        {

        }

        public void SetLatitudeAndLongitude(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
