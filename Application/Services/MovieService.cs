﻿using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IHttpMovieClientService _httpClientService;
        private readonly IMovieRepository _movieRepository;

        public MovieService(IHttpMovieClientService httpClientService, IMovieRepository movieRepository)
        {
            _httpClientService = httpClientService;
            _movieRepository = movieRepository;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            Movie dbMovie = await _movieRepository.GetMovieById(id);

            if (dbMovie == null)
            {
                dynamic apiMovie = JObject.Parse(await _httpClientService.GetMovieById(id));

                dbMovie = GetMovieFromJson(apiMovie);
            }

            return dbMovie;
        }

        private Movie GetMovieFromJson(dynamic apiMovie)
        {
            return new Movie
            {
                Id = apiMovie.id,
                BackdropPath = apiMovie.backdrop_path,
                Budget = apiMovie.budget,
                Genre = new Genre
                {
                    Id = apiMovie.genres[0].id,
                    Name = apiMovie.genres[0].name
                },
                Comments = new List<FilmComment>(),
                HomePage = apiMovie.homepage,
                Overview = apiMovie.overview,
                Popularity = apiMovie.popularity,
                PosterPath = apiMovie.poster_path,
                ReleaseDate = apiMovie.release_date,
                Revenue = apiMovie.revenue,
                RunTime = apiMovie.runtime,
                Title = apiMovie.title,
                VoteAverage = apiMovie.vote_average
            };
        }

        public async Task<string> GetMoviesByName(string query, int page = 1)
        {
            return await _httpClientService.GetMoviesByName(query, page);
        }

        public async Task<string> GetPopularMovies(int page = 1)
        {
            return await _httpClientService.GetPopularMovies(page);
        }

        public async Task<Movie> InsertMovie(Movie movie)
        {
            return await _movieRepository.InsertMovie(movie);
        }
    }
}
