using Application.Auth;
using Application.Common.Interfaces.Auth;
using Application.Dto;
using Application.Services.Auth;
using Domain.Common.Exceptions;
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

        /// <summary>
        /// Prueba que inicia sesión con un usuario correctamente
        /// Verifica que el JWT se haya devuelto satisfactoriamente
        /// </summary>
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

        /// <summary>
        /// Prueba que inicia sesión con un usuario con datos incorrectos
        /// Verifica que se lanza la excepción personalizada
        /// </summary>
        [Fact]
        public async void LoginUserFailPassword()
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

        /// <summary>
        /// Prueba de iniciar sesión con un usuario que su email no exista en la base de datos
        /// Verifica que se lance una excepción personalizada
        /// </summary>
        [Fact]
        public async void LoginUserFailEmail()
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
