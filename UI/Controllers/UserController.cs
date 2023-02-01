using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using UI.Controllers.Base;
using UI.Mapper;
using UI.ViewModels;

namespace UI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        
        public UserController(UserManager<User> userManager, IConfiguration configuration, IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            var user = ApiMapper.Mapper.Map<UserModel>(loginViewModel);
            var token = await _userService.Login(user);
            if(token != null)
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        [HttpPost("Register")]
        public string Register([FromBody] RegisterViewModel registerViewModel)
        {
            var user = ApiMapper.Mapper.Map<UserModel>(registerViewModel);
            return _userService.Register(user);
        }
    }
}
