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
