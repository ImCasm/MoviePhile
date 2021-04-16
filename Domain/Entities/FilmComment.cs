using Domain.Enums;

namespace Domain.Entities
{
    public class FilmComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public int FilmId { get; set; }
        public CommentType CommentType { get; set; }

        public User User { get; set; }
        public Film Film { get; set; }
    }
}
