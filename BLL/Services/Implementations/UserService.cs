using BLL.Mapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;


        public UserService(UserManager<User> userManager,IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<JwtSecurityToken> Login(UserModel userModel)
        {
            var user = await _userManager.FindByEmailAsync(userModel.Email.Normalize());
            UserModel.CurrentUser = user;
            if(user != null && await _userManager.CheckPasswordAsync(user, userModel.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };


                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Token").Value));

                var token = new JwtSecurityToken(
                    issuer: _configuration.GetSection("JWT:ValidIssuer").Value,
                    audience: _configuration.GetSection("JWT:ValidAudience").Value,
                    expires: DateTime.Now.AddMinutes(30),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return token;
            }

            return null;    
        }

        public string Register(UserModel userModel)
        {
            
            var user = ApplicationMapper.Mapper.Map<User>(userModel);
            if (_userManager.FindByEmailAsync(user.Email).Result == null)
            {
                var result = _userManager.CreateAsync(user, user.Password);
                if (result.Result.Succeeded)
                {
                    _unitOfWork.Save();
                    return result.ToString();
                }
                return result.ToString();
            }
            else
            {
                return "User is existed";
            }
            return "User is not registed";
            
        }

    }
}
