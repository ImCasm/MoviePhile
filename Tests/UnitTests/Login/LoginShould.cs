using Application.Auth;
using Application.Common.Interfaces.Auth;
using Application.Dto;
using Application.Services.Auth;
using Domain.Common.Exceptions;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Tests.UnitTests.Login.Mocks;
using Xunit;

namespace Tests.UnitTests.Login
{
    public class LoginShould
    {

        private readonly UserRepositoryMock _userRepository;
        private readonly IAuthService _authService;


        public LoginShould()
        {
            IOptionsMonitor<JwtConfig> om = new TestOptionsMonitor(
                new JwtConfig()
                {
                    Secret = "ijurkbdlhmklqacwqzdxmkkhvqowlyqa"
                }
            );

            _userRepository = new UserRepositoryMock();
            _authService = new AuthService(_userRepository.Object, om);
        }

        [Fact]
        public async void LoginUserSuccess()
        {
            // Arrange
            UserLoginRequestDto userLogin = new UserLoginRequestDto() {
                Email = "admin@gmail.com",
                Password = "123"
            };

            // Act
            AuthResponse user = await _authService.Login(userLogin);

            //Assert
            Assert.NotEmpty(user.Token);
        }

        [Fact]
        public async System.Threading.Tasks.Task LoginUserFailPassword()
        {
            // Arrange
            UserLoginRequestDto userLogin = new UserLoginRequestDto()
            {
                Email = "incorrecto@gmail.com",
                Password = "123"
            };

            // Act

            //Assert
            await Assert.ThrowsAsync<HandlerException>(() => _authService.Login(userLogin));
        }

        [Fact]
        public async System.Threading.Tasks.Task LoginUserFailEmail()
        {
            // Arrange
            UserLoginRequestDto userLogin = new UserLoginRequestDto()
            {
                Email = "noexiste@gmail.com",
                Password = "123"
            };

            // Act

            //Assert
            await Assert.ThrowsAsync<HandlerException>(() => _authService.Login(userLogin));
        }
    }
}
