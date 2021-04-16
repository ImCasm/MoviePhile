namespace Domain.Entities
{
    public class CommunityUser
    {
        public int CommunityId { get; set; }
        public string UserId { get; set; }

        public Community Community { get; set; }
        public User User { get; set; }
    }
}
