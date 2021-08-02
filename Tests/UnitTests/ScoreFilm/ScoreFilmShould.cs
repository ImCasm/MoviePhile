using Application.Common.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.UnitTests.InsertFilm.Mocks;
using Tests.UnitTests.Login.Mocks;
using Tests.UnitTests.ScoreFilm.Mocks;
using Xunit;

namespace Tests.UnitTests.ScoreFilm
{
    public class ScoreFilmShould
    {
        private readonly ScoreFilmRepositoryMock scoreRepository;
        private readonly IScoreService scoreService;
        private readonly IMovieService _movieService;
        private readonly MovieRepositoryMock movieRepository;
        private readonly HttpMovieClientServiceMock httpMovieService;
        private readonly UserRepositoryMock _userRepository;

  

        public ScoreFilmShould()
        {
             httpMovieService = new HttpMovieClientServiceMock();
             movieRepository = new MovieRepositoryMock();
            scoreRepository = new ScoreFilmRepositoryMock();
            _userRepository = new UserRepositoryMock();
            _movieService = new MovieService(httpMovieService.Object, movieRepository.Object);
            scoreService = new ScoreService(scoreRepository.Object, _userRepository.Object,_movieService);
        }
        /// <summary>
        /// Prueba en la que se valida si un valor de la calificación se encuentra dentro de un rango de 0 a 5
        /// </summary>
        [Fact]
        public async void ScoreIsRange()
        {
            // Arrange
            bool scoreResponse;
            Score score = new Domain.Entities.Score()
            {
                 Value=2,
                 FilmId = 588228,
                 UserId = "0a92d309-7651-46df-bd7e-f9a9a51fe3be"


            };

            // Act
            scoreResponse = await scoreService.setScore(score);

            //Assert
            Assert.True(scoreResponse);
        }


  


        [Fact]
        public async void ScoreEmptyUser()
        {
            // Arrange
            bool scoreResponse;
            Score score = new Domain.Entities.Score()
            {
                Value = 2,
                FilmId = 588228,
               

            };

            // Act
            scoreResponse = await scoreService.setScore(score);

            //Assert
            Assert.False(scoreResponse);
        }


    }
}
