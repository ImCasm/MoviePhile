using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UnitTests.ScoreFilm.Mocks
{
    public class ScoreFilmRepositoryMock : Mock<IScoreRepository>
    {

        public ScoreFilmRepositoryMock() {
            SetupMethods();
        }

        public void SetupSetScore()
        {
        
            
            Setup(x => x.setScore(It.Is<Score>(scoreFilm => scoreFilm.Value > 0 | scoreFilm.Value<5))).Returns(Task.FromResult(true));
            Setup(x => x.setScore(It.Is<Score>(scoreFilm => scoreFilm.Value < 1 | scoreFilm.Value > 5))).Returns(Task.FromResult(false));
            Setup(x => x.setScore(It.Is<Score>(scoreFilm=> String.IsNullOrEmpty(scoreFilm.UserId)))).Returns(Task.FromResult(false));
        

        }



        private void SetupMethods()
        {
            SetupSetScore();
        }

    }
}
