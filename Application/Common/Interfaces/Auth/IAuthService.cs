using Application.Dto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(UserLoginRequestDto user);
        Task<AuthResponse> Register(UserRegisterRequestDto user);
        string GenerateJwtToken(IdentityUser user);
    }
}
