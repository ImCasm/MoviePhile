using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Moq;
using System.Threading.Tasks;

namespace Tests.UnitTests.InsertFilm.Mocks
{
    public class MovieRepositoryMock : Mock<IMovieRepository>
    {

        public MovieRepositoryMock()
        {
            SetupMethods();
        }

        public void SetupGetMovieById()
        {
            Setup(x => x.GetMovieById(It.Is<int>(id => id < 100)))
                .Returns(Task.FromResult(
                    new Movie
                    {
                        Id = 3,
                        Title = "Titanic",
                    })
                );
        }

        public void SetupInsertMovie()
        {
            Setup(x => x.InsertMovie(It.Is<Movie>(movie => movie != null)))
                .Returns(Task.FromResult(
                    new Movie
                    {
                        Id = 3,
                        Title = "Titanic",
                    })
                );
        }

        private void SetupMethods()
        {
            SetupGetMovieById();
            SetupInsertMovie();
        }
    }
}
