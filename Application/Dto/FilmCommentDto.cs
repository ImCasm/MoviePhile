using Domain.Enums;

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
