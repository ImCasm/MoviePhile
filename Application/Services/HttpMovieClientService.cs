using Application.Common.Interfaces.HttpClient;
using Application.Common.Interfaces.Services;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HttpMovieClientService : IHttpMovieClientService
    {
        private readonly IHttpMovieClient _httpClient;

        public HttpMovieClientService(IHttpMovieClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetMoviesByName(string query, int page)
        {
            return await _httpClient.GetMoviesByName(query, page);
        }

        public async Task<string> GetPopularMovies(int page)
        {
            return await _httpClient.GetPopularMovies(page);
        }
    }
}
