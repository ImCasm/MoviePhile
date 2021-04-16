using System.Collections.Generic;

namespace Domain.Entities
{
    public abstract class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string HomePage { get; set; }
        public string BackdropPath { get; set; }
        public string PosterPath { get; set; }
        public float Popularity { get; set; }
        public float VoteAverage { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<FilmComment> Comments { get; set; }
    }
}
