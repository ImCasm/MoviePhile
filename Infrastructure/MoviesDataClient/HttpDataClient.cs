using Application.Common.Interfaces.HttpClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.MoviesDataClient
{
    public class HttpDataClient : IHttpMovieClient
    {

        private readonly HttpClient _httpClient;

        public HttpDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetMovies(string query, int page)
        {
            const string API_KEY = "720f1f9c1df65a0ff47c3efd52a055c2";
            string API_URL = $"search/movie?api_key={API_KEY}&language=es&query={query}&page={page}";

            var response = await _httpClient.GetAsync(API_URL);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
