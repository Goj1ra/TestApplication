
using BLL.Models;
using System.IdentityModel.Tokens.Jwt;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<JwtSecurityToken> Login(UserModel user);
        string Register(UserModel user);
    }
}
