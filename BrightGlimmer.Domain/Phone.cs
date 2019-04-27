using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BrightGlimmer.Domain
{
    [Table("Phones")]
    public class Phone : Entity
    {
        public PhoneType Type { get; private set; }
        public int AreaCode { get; private set; }
        public int Number { get; private set; }

        private Phone() { }

        public Phone(PhoneType type, int areaCode, int number)
        {
            Type = type;
            AreaCode = areaCode;
            Number = number;
        }
    }
}
