using Application.Common.Interfaces.Services;
using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MoviePhile.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<ActionResult> GetMoviesByName(string query, int page = 1)
        {
            return Content(await _movieService.GetMoviesByName(query, page), "application/json");
        }

        [HttpGet("popular")]
        public async Task<ActionResult> GetPopularMovies(int page = 1)
        {
            return Content(await _movieService.GetPopularMovies(page), "application/json");
        }

        [HttpGet]
        public async Task<ActionResult> GetMovieById(int movieId)
        {
            return Ok(_mapper.Map<MovieDto>(await _movieService.GetMovieById(movieId)));
        }

        [HttpPost]
        public async Task<ActionResult> InsertMovie(Movie movie)
        {
            return Ok(_mapper.Map<MovieDto>(await _movieService.InsertMovie(movie)));
        }
    }
}
