using Application.Common.Interfaces.HttpClient;
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
        private readonly IHttpMovieClient _httpClient;

        public MoviesController(IHttpMovieClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("search")]
        public async Task<ActionResult> GetMoviesByName(string query, int page = 1)
        {
            return Content(await _httpClient.GetMoviesByName(query, page), "application/json");
        }

        [HttpGet("popular")]
        public async Task<ActionResult> GetPopularMovies(int page = 1)
        {
            return Content(await _httpClient.GetPopularMovies(page), "application/json");
        }
    }
}
