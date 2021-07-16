using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Publication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int CommunityId { get; set; }

        public ICollection<PublicationComment> Comments { get; set; }
        public Community Community { get; set; }
        public User User { get; set; }

    }
}
