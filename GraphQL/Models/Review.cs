using System;

namespace ProductReviews.Models
{
    public class Review
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }

        public int ProductId { get; set; }

        public string Reviewer { get; set; }

        public int Rating { get; set; }

        public string Text { get; set; }
    }
}