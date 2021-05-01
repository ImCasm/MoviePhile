using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Services
{
    public class GenreService : IGenreService
    {

        private readonly IHttpMovieClientService _httpClientService;
        private readonly IGenreRepository _genreRepository;

        public GenreService(IHttpMovieClientService httpClientService, IGenreRepository genreRepository)
        {
            _httpClientService = httpClientService;
            _genreRepository = genreRepository;
        }

        public async Task<ICollection<Genre>> GetAllGenres()
        {
            return await _genreRepository.GetGenres();
        }

        public async Task<ICollection<Genre>> GetAllMovieGenres()
        {
            string genresString = await _httpClientService.GetAllMovieGenres();

            dynamic genresJson = JObject.Parse(genresString);

            var genresList = GetGenresListFromJson(genresJson.genres);

            return genresList;
        }

        public async Task<ICollection<Genre>> GetAllSeriesGenres()
        {
            string genresString = await _httpClientService.GetAllSeriesGenres();

            dynamic genresJson = JObject.Parse(genresString);

            var genresList = GetGenresListFromJson(genresJson.genres);

            return genresList;
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return (await GetAllGenres()).FirstOrDefault(genre => genre.Id == id);
        }

        /// <summary>
        /// Convierte una lista en formato JSON a una lista de generos
        /// </summary>
        /// <param name="genresJSON">Lista en JSON</param>
        /// <returns>Lista de generos</returns>
        private ICollection<Genre> GetGenresListFromJson(dynamic genresJSON)
        {
            ICollection<Genre> genres = new List<Genre>();

            foreach (var genre in genresJSON)
            {
                genres.Add(
                    new Genre
                    {
                        Id = genre.id,
                        Name = genre.name
                    }
                );
            }

            return genres;
        }
    }
}
