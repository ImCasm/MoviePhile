using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.HttpClient
{
    public interface IHttpMovieClient
    {
        Task<string> GetMoviesByName(string query, int page);
        Task<string> GetPopularMovies(int page);
    }
}
