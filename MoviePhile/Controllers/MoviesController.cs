using Application.Common.Interfaces.Services;
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
        private readonly IHttpMovieClientService _httpClientService;

        public MoviesController(IHttpMovieClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        [HttpGet("search")]
        public async Task<ActionResult> GetMoviesByName(string query, int page = 1)
        {
            return Content(await _httpClientService.GetMoviesByName(query, page), "application/json");
        }

        [HttpGet("popular")]
        public async Task<ActionResult> GetPopularMovies(int page = 1)
        {
            return Content(await _httpClientService.GetPopularMovies(page), "application/json");
        }
    }
}
