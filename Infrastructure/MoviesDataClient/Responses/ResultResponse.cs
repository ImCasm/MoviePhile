using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.MoviesDataClient.Responses
{
    public class ResultResponse
    {
        public int Page { get; set; }
        public IEnumerable<MovieResponse> Results { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
    }
}
