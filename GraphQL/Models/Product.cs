using System.Collections.Generic;

namespace ProductReviews.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Review> Reviews { get; set; }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }
    }
}