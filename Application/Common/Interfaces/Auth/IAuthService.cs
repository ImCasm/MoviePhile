using Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(UserLoginRequestDto user);

        Task<AuthResponse> Register(UserRegisterRequestDto user);
    }
}
