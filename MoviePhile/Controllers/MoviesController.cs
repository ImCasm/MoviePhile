using Application.Common.Interfaces.HttpClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MoviePhile.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IHttpMovieClient _httpClient;

        public MoviesController(IHttpMovieClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string query, int page = 1)
        {
            return Content(await _httpClient.GetMovies(query, page), "application/json");
        }
    }
}
