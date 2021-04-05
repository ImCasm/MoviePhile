using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.HttpClient
{
    public interface IHttpMovieClient
    {
        Task<string> GetMovies(string query, int page);
    }
}
