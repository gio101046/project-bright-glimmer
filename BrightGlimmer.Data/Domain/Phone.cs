using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Data.Domain
{
    public class Phone
    {
        public Guid Id { get; set; }
        public PhoneType Type { get; set; }
        public int AreaCode { get; set; }
        public int Number { get; set; }
    }
}
