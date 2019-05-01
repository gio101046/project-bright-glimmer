using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BrightGlimmer.Domain
{
    [Table("Phones")]
    public class Phone : Entity
    {
        [JsonProperty]
        public PhoneType Type { get; private set; }
        [JsonProperty]
        public int AreaCode { get; private set; }
        [JsonProperty]
        public int Number { get; private set; }

        protected Phone() { }

        public Phone(PhoneType type, int areaCode, int number)
        {
            Type = type;
            AreaCode = areaCode;
            Number = number;
        }

        public Phone(Phone phone)
        {
            Type = phone.Type;
            AreaCode = phone.AreaCode;
            Number = phone.Number;
        }

        internal void Update(Phone phone)
        {
            Type = phone.Type;
            AreaCode = phone.AreaCode;
            Number = Number;
        }
    }
}
