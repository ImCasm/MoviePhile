using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FilmCommentService : IFilmCommentService
    {
        private readonly IFilmCommentRepository _repository;

        public FilmCommentService(IFilmCommentRepository repository)
        {
            _repository = repository;
        }
              

        public async Task<bool> SetComment(FilmComment filmComment)
        {
            return  await _repository.SetFilmComment(filmComment);
        }

        public async Task<IEnumerable<FilmComment>> GetAllComment(int IdFilm)
        {
            return await _repository.GetAllComment(IdFilm);
        }
    }
}
