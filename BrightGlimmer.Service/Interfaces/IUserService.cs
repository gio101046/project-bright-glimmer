using BrightGlimmer.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrightGlimmer.Service.Interfaces
{
    public interface IUserService
    {
        string Login(string username, string password);
        Task<string> RegisterAsync(User user, string password);
    }
}
