using Application.Auth;
using Application.Common.Interfaces.Auth;
using Application.Dto;
using Domain.Common.Exceptions;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Auth
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly JwtConfig _jwtConfig;

        public AuthService(IUserRepository authRepository, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userRepository = authRepository;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        public async Task<AuthResponse> Login(UserLoginRequestDto user)
        {
            if (await _userRepository.UserExists(user.Email))
            {
                var existingUser = await _userRepository.FindByEmail(user.Email);

                if (await _userRepository.CheckCredentials(existingUser, user.Password))
                {
                    var jwtToken = GenerateJwtToken(existingUser);

                    return new AuthResponse()
                    {
                        Result = true,
                        Token = jwtToken
                    };
                }


                throw new HandlerException(
                    HttpStatusCode.Unauthorized,
                    new List<string>() {
                        "El usuario/password son incorrectos."
                    }
                );
            }

            throw new HandlerException(
                HttpStatusCode.NotFound,
                new List<string>() {
                    "El usuario no se encuentra en el sistema."
                }
            );
        }

        public async Task<AuthResponse> Register(UserRegisterRequestDto user)
        {

            if (await _userRepository.UserExists(user.Email))
            {
                return new AuthResponse()
                {
                    Result = false,
                    Errors = new List<string>(){
                        "Email ya existe"
                    }
                };
            }

            var newUser = new User() { Email = user.Email, UserName = user.Email };
            var isCreated = await _userRepository.CreateUser(newUser, user.Password);

            if (isCreated.Succeeded)
            {
                var jwtToken = GenerateJwtToken(newUser);

                return new AuthResponse()
                {
                    Result = true,
                    Token = jwtToken
                };
            }

            throw new HandlerException(
                HttpStatusCode.InternalServerError,
                isCreated.Errors.Select(x => x.Description).ToList()
            );
        }

        public string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
