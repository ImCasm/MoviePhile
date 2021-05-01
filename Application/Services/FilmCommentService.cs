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
        private readonly IMovieService _movieService;

        public FilmCommentService(IFilmCommentRepository repository, IMovieService movieService)
        {
            _repository = repository;
            _movieService = movieService;
        }
              

        public async Task<bool> SetComment(FilmComment filmComment)
        {
            if (! await _movieService.ExistMovieOnDb(filmComment.FilmId))
            {
                Movie movie = await _movieService.GetMovieById(filmComment.FilmId);
                await _movieService.InsertMovie(movie);
            }

            return  await _repository.SetFilmComment(filmComment);
        }

        public async Task<IEnumerable<FilmComment>> GetAllComment(int IdFilm)
        {
            return await _repository.GetAllComment(IdFilm);
        }
    }
}
