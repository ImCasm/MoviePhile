using System;

namespace Domain.Entities
{
    public class TvShow : Film
    {
        public int NumberOfEpisodes { get; set; }
        public int NumberOfSeasons { get; set; }
        public DateTime FirstAirDate { get; set; }
    }
}
