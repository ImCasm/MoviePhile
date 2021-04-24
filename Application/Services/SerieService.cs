using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SerieService : ISerieService
    {
        private readonly IHttpMovieClientService _httpClientService;
        private readonly ISerieRepository _serieRepository;

        public SerieService(IHttpMovieClientService httpClientService, ISerieRepository serieRepository)
        {
            _httpClientService = httpClientService;
            _serieRepository = serieRepository;
        }

        public async Task<string> GetPopularSeries(int page)
        {
            return await _httpClientService.GetPopularSeries(page);
        }

        public async Task<TvShow> GetSerieById(int id)
        {
            TvShow dbSerie = await _serieRepository.GetSerieById(id);

            if (dbSerie == null)
            {
                dynamic apiSerie = JObject.Parse(await _httpClientService.GetSerieById(id));

                dbSerie = GetSerieFromJson(apiSerie);
            }

            return dbSerie;
        }

        private TvShow GetSerieFromJson(dynamic apiSerie)
        {
            return new TvShow
            {
                Id = apiSerie.id,
                BackdropPath = apiSerie.backdrop_path,
                Genre = new Genre
                {
                    Id = apiSerie.genres[0].id,
                    Name = apiSerie.genres[0].name
                },
                Comments = new List<FilmComment>(),
                HomePage = apiSerie.homepage,
                Overview = apiSerie.overview,
                Popularity = apiSerie.popularity,
                PosterPath = apiSerie.poster_path,
                Title = apiSerie.title,
                VoteAverage = apiSerie.vote_average,
                FirstAirDate = apiSerie.first_air_date,
                NumberOfEpisodes = apiSerie.number_of_episodes,
                NumberOfSeasons = apiSerie.number_of_seasons
            };
        }

        public async Task<string> GetSeriesByName(string query, int page)
        {
            return await _httpClientService.GetSeriesByName(query, page);
        }
    }
}
