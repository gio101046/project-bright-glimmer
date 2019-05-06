using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BrightGlimmer.Auth.Request;
using BrightGlimmer.Domain.Auth;
using BrightGlimmer.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BrightGlimmer.Auth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string username, string password)
        {
            var token = userService.Login(username, password);
            return new JsonResult(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterUserRequest request)
        {
            var token = await userService.RegisterAsync(request.User, request.Password);
            return new JsonResult(token);
        }
    }
}
