using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.UnitTests.SearchMovie.Mocks
{
    public class FilmCommentRepositoryMock : Mock<IFilmCommentRepository>
    {


        public FilmCommentRepositoryMock()
        {           
            SetupMethods();
        }

        public void SetupSetFilmComment()
        {
            Setup(x => x.SetFilmComment(It.Is<FilmComment>(filmComment => !string.IsNullOrEmpty(filmComment.Content))))
                .Returns(Task.FromResult(true));

            Setup(x => x.SetFilmComment(It.Is<FilmComment>(filmComment =>string.IsNullOrEmpty(filmComment.Content) )))
                .Returns(Task.FromResult(false));

            Setup(x => x.SetFilmComment(It.Is<FilmComment>(filmComment => string.IsNullOrEmpty(filmComment.UserId))))
               .Returns(Task.FromResult(false));

        }



        private void SetupMethods()
        {
            SetupSetFilmComment();
        }
    }
}
