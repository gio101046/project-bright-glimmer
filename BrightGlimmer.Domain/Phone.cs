using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Domain
{
    public class Phone : Entity
    {
        public PhoneType Type { get; set; }
        public int AreaCode { get; set; }
        public int Number { get; set; }
    }
}
