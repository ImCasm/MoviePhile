using Application.Common.Interfaces.Services;
using Application.Services;
using Domain.Common.Exceptions;
using Domain.Entities;
using Tests.UnitTests.InsertFilm.Mocks;
using Xunit;

namespace Tests.UnitTests.InsertFilm
{
    public class InsertFilmShould
    {
        private readonly MovieRepositoryMock movieRepository;
        private readonly HttpMovieClientServiceMock httpMovieService;
        private readonly IMovieService movieService;

        public InsertFilmShould()
        {
            movieRepository = new MovieRepositoryMock();
            httpMovieService = new HttpMovieClientServiceMock();
            movieService = new MovieService(httpMovieService.Object, movieRepository.Object);
        }

        /// <summary>
        /// Prueba de insertar una película valida en la base de datos
        /// Verifica que el id sea el esperado
        /// </summary>
        [Fact]
        public async void InsertFilmSuccess()
        {
            // Arrange
            Movie movie;

            // Act
            movie = await movieService.InsertMovie(
                new Movie()
                {
                    Id = 3,
                    GenreId = 19
                }
            );

            //Assert
            Assert.Equal(3, movie.Id);
        }

        /// <summary>
        /// Prueba de insertar una película con datos incorrectos en la base de datos, GenreId es 0
        /// Verifica que se haya lanzado la excepción
        /// </summary>
        [Fact]
        public async void InsertFilmError()
        {
          

            //Assert
            await Assert.ThrowsAnyAsync<HandlerException>(() => movieService.InsertMovie( new Movie() {Id = 3}));
        }
    }
}
