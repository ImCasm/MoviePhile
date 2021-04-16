using System;

namespace Domain.Entities
{
    public class Advertising
    {
        public int Id { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public int FilmId { get; set; }
        public string UserId { get; set; }
        public int PaymentId { get; set; }

        public Film Film { get; set; }
        public User User { get; set; }
        public Payment Payment { get; set; }
    }
}
