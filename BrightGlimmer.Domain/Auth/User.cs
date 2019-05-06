using System;
using System.Collections.Generic;
using System.Text;

namespace BrightGlimmer.Domain.Auth
{
    public class User : Entity
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }

        /* TODO: Missing DOB */

        public string PasswordHash { get; set; }
        public bool EmailConfirmed { get; private set; }
        public bool AccountLocked { get; private set; }
        public int RetryAttempts { get; private set; }
    }
}
