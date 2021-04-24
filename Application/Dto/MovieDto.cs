using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class MovieDto : FilmDto
    {
        public int Budget { get; set; }
        public int Revenue { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunTime { get; set; }
    }
}
