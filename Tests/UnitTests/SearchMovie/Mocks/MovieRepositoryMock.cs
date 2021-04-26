using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.UnitTests.SearchMovie.Mocks
{
    public class MovieRepositoryMock : Mock<IMovieRepository>
    {
        private readonly IList<Movie> movies;

        public MovieRepositoryMock()
        {
            movies = new List<Movie> {
                new Movie
                {
                    Id = 1,
                    Title = "El padrino",
                },
                new Movie
                {
                    Id = 2,
                    Title = "Interestellar",
                },
                new Movie
                {
                    Id = 3,
                    Title = "Matrix",
                },
                new Movie
                {
                    Id = 3,
                    Title = "Titanic",
                }
            };

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

        private void SetupMethods()
        {
            SetupGetMovieById();
        }
    }
}
