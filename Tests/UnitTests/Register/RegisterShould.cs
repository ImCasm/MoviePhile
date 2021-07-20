using Application.Auth;
using Application.Common.Interfaces.Auth;
using Application.Dto;
using Application.Services.Auth;
using Microsoft.Extensions.Options;
using Tests.UnitTests.Login.Mocks;
using Xunit;

namespace Tests.UnitTests.Register
{
    public class RegisterShould
    {
        private readonly IAuthService _authService;
        private readonly UserRepositoryMock _userRepository;

        public RegisterShould()
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
        /// Prueba para registrar a un usuario nuevo
        /// Debe retornal contenido en el roken que devuelve
        /// </summary>
        [Fact]
        public async void RegisterUserSuccess()
        {
            // Arrange
            UserRegisterRequestDto user = new UserRegisterRequestDto()
            {
                Email = "noexiste@gmail.com",
                Name = "Usuario nuevo",
                Password = "Abcd1234$"
            };

            // Act
            AuthResponse response = await _authService.Register(user);

            //Assert
            Assert.NotEmpty(response.Token);
        }

        /// <summary>
        /// Prueba para registrar un usuario existente
        /// La respuesta debe tener el token null y el resultado False
        /// </summary>
        [Fact]
        public async void RegisterExistingUser()
        {
            // Arrange
            UserRegisterRequestDto user = new UserRegisterRequestDto()
            {
                Email = "existe@gmail.com",
                Name = "Usuario existente",
                Password = "Abcd1234$"
            };

            // Act
            AuthResponse response = await _authService.Register(user);

            //Assert
            Assert.Null(response.Token);
            Assert.False(response.Result);
        }
    }
}
