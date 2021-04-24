using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class FilmCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public CommentType CommentType { get; set; }

        public UserDto User { get; set; }
    }
}
