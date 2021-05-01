using Application.Common.Interfaces.HttpClient;
using Domain.Common.Exceptions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.MoviesDataClient
{
    public class HttpDataClient : IHttpMovieClient
    {

        private readonly HttpClient _httpClient;
        private const string API_KEY = "720f1f9c1df65a0ff47c3efd52a055c2";

        public HttpDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetMoviesByName(string query, int page)
        {
            string URL = $"search/movie?api_key={API_KEY}&language=es&query={query}&page={page}";
            var response = await _httpClient.GetAsync(URL);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPopularMovies(int page)
        {
            string URL = $"movie/popular?api_key={API_KEY}&language=es&page={page}";
            var response = await _httpClient.GetAsync(URL);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetMovieById(int id)
        {
            string URL = $"movie/{id}?api_key={API_KEY}&language=es";
            var response = await _httpClient.GetAsync(URL);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new HandlerException(
                response.StatusCode,
                new List<string>() {
                    await response.Content.ReadAsStringAsync()
                }
            );
        }

        public async Task<string> GetSeriesByName(string query, int page)
        {
            string URL = $"search/tv?api_key={API_KEY}&language=es&query={query}&page={page}";
            var response = await _httpClient.GetAsync(URL);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPopularSeries(int page)
        {
            string URL = $"tv/popular?api_key={API_KEY}&language=es&page={page}";
            var response = await _httpClient.GetAsync(URL);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetSerieById(int id)
        {
            string URL = $"tv/{id}?api_key={API_KEY}&language=es";
            var response = await _httpClient.GetAsync(URL);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new HandlerException(
                response.StatusCode,
                new List<string>() {
                    await response.Content.ReadAsStringAsync()
                }
            );
        }

        public async Task<string> GetAllMovieGenres()
        {
            string URL = $"genre/movie/list?api_key={API_KEY}&language=es";
            var response = await _httpClient.GetAsync(URL);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new HandlerException(
                response.StatusCode,
                new List<string>() {
                    await response.Content.ReadAsStringAsync()
                }
            );
        }

        public async Task<string> GetAllSeriesGenres()
        {
            string URL = $"genre/tv/list?api_key={API_KEY}&language=es";
            var response = await _httpClient.GetAsync(URL);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new HandlerException(
                response.StatusCode,
                new List<string>() {
                    await response.Content.ReadAsStringAsync()
                }
            );
        }
    }
}
