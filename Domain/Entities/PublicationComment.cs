using System;

namespace Domain.Entities
{
    public class PublicationComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int PublicationId { get; set; }

        public User User { get; set; }
        public Publication Publication { get; set; }
    }
}
