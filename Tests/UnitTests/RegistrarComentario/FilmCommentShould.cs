using Application.Common.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Newtonsoft.Json.Linq;
using Tests.UnitTests.RegistrarComentario.Mocks;
using Tests.UnitTests.SearchMovie.Mocks;
using Xunit;

namespace Tests.UnitTests.RegistrarComentario
{
    public class FilmCommentShould
    {

        private readonly FilmCommentRepositoryMock filmCommentRepository;
        private readonly MovieRepositoryMock movieRepository;
        private readonly HttpMovieClientServiceMock httpMovieService;
        private readonly IFilmCommentService filmCommenService;
        private readonly IMovieService movieService;

        public FilmCommentShould()
        {
            httpMovieService = new HttpMovieClientServiceMock();
            movieRepository = new MovieRepositoryMock();
            filmCommentRepository = new FilmCommentRepositoryMock();

            movieService = new MovieService(httpMovieService.Object, movieRepository.Object);
            filmCommenService = new FilmCommentService(filmCommentRepository.Object, movieService);
        }

        [Fact]
        public async void FilmCommentContentIsEmpty()
        {
            // Arrange
            bool filmCommentResponse;
            FilmComment filmComment=new Domain.Entities.FilmComment()
            {
                Content = "",
                UserId = "0a92d309-7651-46df-bd7e-f9a9a51fe3be",
                FilmId = 399566,
                CommentType = (Domain.Enums.CommentType)1
            };
                      
            // Act
            filmCommentResponse = await filmCommenService.SetComment(filmComment);

            //Assert
            Assert.False(filmCommentResponse);
        }

        [Fact]
        public async void FilmCommentContentIsNotEmpty()
        {
            // Arrange
            bool filmCommentResponse;
            FilmComment filmComment = new Domain.Entities.FilmComment() {
                Content= "Comentario de la película",
                UserId= "0a92d309-7651-46df-bd7e-f9a9a51fe3be",
                FilmId= 399566,
                CommentType= (Domain.Enums.CommentType)1
                };
            // Act
            filmCommentResponse = await filmCommenService.SetComment(filmComment);
            //Assert
            Assert.True(filmCommentResponse);
        }


        [Fact]
        public async void FilmCommentIdFilmIsEmpty()
        {
            // Arrange
            bool filmCommentResponse;
            FilmComment filmComment = new Domain.Entities.FilmComment()
            {
                Content = "Comentario de la película",
                UserId = "",
                FilmId = 399566,
                CommentType = (Domain.Enums.CommentType)1
            };

            // Act
            filmCommentResponse = await filmCommenService.SetComment(filmComment);

            //Assert
            Assert.False(filmCommentResponse);
        }
    }
}
