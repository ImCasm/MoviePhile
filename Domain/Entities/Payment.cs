using System;

namespace Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}
