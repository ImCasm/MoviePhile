using System;

namespace Application.Dto
{
    public class TvShowDto : FilmDto
    {
        public int NumberOfEpisodes { get; set; }
        public int NumberOfSeasons { get; set; }
        public DateTime FirstAirDate { get; set; }
    }
}
