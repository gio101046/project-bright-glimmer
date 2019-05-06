using System;
using System.Security.Cryptography;

namespace BrightGlimmer.Tools
{
    public class PasswordHasher
    {
        private readonly int SALT_LENGTH = 16;
        private readonly int PASS_LENGTH = 20;
        private readonly int ITERATIONS = 10000;

        public bool Verify(string password, string hash)
        {
            var storedHash = Convert.FromBase64String(hash);

            var salt = new byte[SALT_LENGTH];
            Array.Copy(storedHash, 0, salt, 0, SALT_LENGTH);

            var givenHash = GetHash(password, salt);

            return hash == givenHash;
        }

        public string GetHash(string password, byte[] salt = null)
        {
            if (salt == null)
            {
                salt = CreateSalt();
            }
            var hash = CreateHash(password, salt);

            var completeHash = new byte[SALT_LENGTH + PASS_LENGTH];
            Array.Copy(salt, 0, completeHash, 0, SALT_LENGTH);
            Array.Copy(hash, 0, completeHash, SALT_LENGTH, PASS_LENGTH);

            return Convert.ToBase64String(completeHash);
        }

        private byte[] CreateHash(string password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS);
            return pbkdf2.GetBytes(PASS_LENGTH);
        }

        private byte[] CreateSalt()
        {
            var salt = new byte[SALT_LENGTH];
            new RNGCryptoServiceProvider().GetBytes(salt);

            return salt;
        }
    }
}
