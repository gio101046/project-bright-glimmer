using BrightGlimmer.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrightGlimmer.Auth.Request
{
    public class RegisterUserRequest
    {
        public User User { get; set; }
        public string Password { get; set; }
    }
}
