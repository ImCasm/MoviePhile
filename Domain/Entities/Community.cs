using System.Collections.Generic;

namespace Domain.Entities
{
    public class Community
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Publication> Publications { get; set; }
        public ICollection<CommunityUser> Users { get; set; }
    }
}
