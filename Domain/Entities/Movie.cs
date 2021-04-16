using System;

namespace Domain.Entities
{
    public class Movie : Film
    {
        public int Budget { get; set; }
        public int Revenue { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunTime { get; set; }
    }
}
