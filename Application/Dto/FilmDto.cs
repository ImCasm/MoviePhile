using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string HomePage { get; set; }
        public string BackdropPath { get; set; }
        public string PosterPath { get; set; }
        public float Popularity { get; set; }
        public float VoteAverage { get; set; }

        public GenreDto Genre { get; set; }
        public ICollection<FilmCommentDto> Comments { get; set; }

        public float Score { get; set; }

    }
}
