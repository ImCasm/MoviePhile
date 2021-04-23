using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CommentFilmDTO
    {
       
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public string UserId { get; set; }
        public int FilmId { get; set; }
        public CommentType CommentType { get; set; }


    }
}
