using Application.Common.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Newtonsoft.Json.Linq;
using Tests.UnitTests.SearchMovie.Mocks;
using Xunit;

namespace Tests.UnitTests.SearchMovie
{
    public class SearchFilmShould
    {

        private readonly MovieRepositoryMock movieRepository;
        private readonly HttpMovieClientServiceMock httpMovieService;
        private readonly IMovieService movieService;

        public SearchFilmShould()
        {
            movieRepository = new MovieRepositoryMock();
            httpMovieService = new HttpMovieClientServiceMock();
            movieService = new MovieService(httpMovieService.Object, movieRepository.Object);
        }

        /// <summary>
        /// Prueba de trae una película de la base de datos
        /// Verifica que no sea null
        /// </summary>
        [Fact]
        public async void SearchMovieByIdFromDb()
        {
            // Arrange
            Movie movie;

            // Act
            movie = await movieService.GetMovieById(3);

            //Assert
            Assert.NotNull(movie);
        }

        /// <summary>
        /// Prueba de traer película por id desde la API externa
        /// Verifica que no sea null
        /// </summary>
        [Fact]
        public async void SearchMovieByIdFromApi()
        {
            // Arrange
            Movie movie;

            // Act
            movie = await movieService.GetMovieById(100);

            //Assert
            Assert.NotNull(movie);
        }

        /// <summary>
        /// Prueba que trae lista de películas desde la API externa
        /// Verifica que la primer película de la lista sea la esperada
        /// </summary>
        [Fact]
        public async void SearchMoviesByName()
        {
            // Arrange
            string stringMovies;

            // Act
            stringMovies = await movieService.GetMoviesByName("Mortal Kombat");
            var moviesJson = JArray.Parse(stringMovies);

            //Assert
            Assert.Equal("Mortal Kombat", moviesJson[0]["title"]);
        }

        /// <summary>
        /// Prueba que trae la lista de películas porpulares de la API externa
        /// Verifica que la lista no esté vacía
        /// </summary>
        [Fact]
        public async void SearchPopularMovies()
        {
            // Arrange
            string stringMovies;

            // Act
            stringMovies = await movieService.GetPopularMovies();
            var moviesJson = JArray.Parse(stringMovies);

            //Assert
            Assert.NotEmpty(moviesJson);
        }
    }
}
