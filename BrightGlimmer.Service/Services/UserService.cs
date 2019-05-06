using BrightGlimmer.Data;
using BrightGlimmer.Domain.Auth;
using BrightGlimmer.Service.Interfaces;
using BrightGlimmer.Tools;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BrightGlimmer.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration configuration;
        private readonly AuthContext context;

        public UserService(IConfiguration configuration, AuthContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        public string Login(string username, string password)
        {
            var user = context.Users.SingleOrDefault(x => x.Username == username);
            var hasher = new PasswordHasher();

            if (user == null || hasher.Verify(password, user.PasswordHash))
            {
                return CreateAuthToken(username, user.Email);
            }

            return null;
        }

        public async Task<string> RegisterAsync(User user, string password)
        {
            /* TODO: Perform validation on user */

            var hasher = new PasswordHasher();
            var hash = hasher.GetHash(password);
            user.PasswordHash = hash;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return CreateAuthToken(user.Username, user.Email);
        }

        private string CreateAuthToken(string username, string email)
        {
            var tokenCreator = new JwtTokenCreator(configuration.GetSection("Keys")["JwtPrivateKey"]);
            return tokenCreator.CreateToken(username, email);
        }
    }
}
