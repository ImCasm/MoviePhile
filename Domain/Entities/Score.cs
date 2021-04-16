namespace Domain.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }

        public Film Film { get; set; }
        public User User { get; set; }
    }
}
