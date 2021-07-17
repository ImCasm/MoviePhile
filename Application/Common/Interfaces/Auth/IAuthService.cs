using Application.Dto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Auth
{
    public interface IAuthService
    {
        /// <summary>
        /// Permite iniciar sesión con un usuario
        /// </summary>
        /// <param name="user">Datos del usuario</param>
        /// <returns>Respuesta de autenticación</returns>
        Task<AuthResponse> Login(UserLoginRequestDto user);

        /// <summary>
        /// Permite registrar un usuario
        /// </summary>
        /// <param name="user">Datos del usuario</param>
        /// <returns>Repsuesta de registro</returns>
        Task<AuthResponse> Register(UserRegisterRequestDto user);
        
        /// <summary>
        /// Genera el jwt para enviarlo al usuario autenticado
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string GenerateJwtToken(IdentityUser user);
    }
}
