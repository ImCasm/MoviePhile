using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IHttpMovieClientService
    {
        Task<string> GetMoviesByName(string query, int page);
        Task<string> GetPopularMovies(int page);
    }
}
