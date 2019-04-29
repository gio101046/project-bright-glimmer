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
        public string StreetAddress1 { get; private set; }
        public string StreetAddress2 { get; private set; }
        public string City { get; private set; }
        public string StateCode { get; private set; }
        public string County { get; private set; }
        public string ZipCode { get; private set; }
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

        internal void Update(Address address)
        {
            StreetAddress1 = address.StreetAddress1;
            StreetAddress2 = address.StreetAddress2;
            City = address.City;
            StateCode = address.StateCode;
            County = address.County;
            ZipCode = address.ZipCode;
        }

        public void SetLatitudeAndLongitude(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
