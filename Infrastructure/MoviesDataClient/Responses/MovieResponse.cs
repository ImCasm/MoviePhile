using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.MoviesDataClient.Responses
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public IEnumerable<int> GenreIds { get; set; }
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public string Overview { get; set; }
        public float Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}
