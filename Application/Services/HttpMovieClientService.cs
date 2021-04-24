using Application.Common.Interfaces.HttpClient;
using Application.Common.Interfaces.Services;
using Domain.Entities;
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

        public async Task<string> GetMovieById(int id)
        {
            return await _httpClient.GetMovieById(id);
        }

        public async Task<string> GetMoviesByName(string query, int page)
        {
            return await _httpClient.GetMoviesByName(query, page);
        }

        public async Task<string> GetPopularMovies(int page)
        {
            return await _httpClient.GetPopularMovies(page);
        }

        public async Task<string> GetPopularSeries(int page)
        {
            return await _httpClient.GetPopularSeries(page);
        }

        public async Task<string> GetSerieById(int id)
        {
            return await _httpClient.GetSerieById(id);
        }

        public async Task<string> GetSeriesByName(string query, int page)
        {
            return await _httpClient.GetSeriesByName(query, page);
        }
    }
}
