using GraphQL.Types;
using ProductReviews.Models;

namespace ProductReviews.GraphQL.Types
{
    public sealed class ReviewObject : ObjectGraphType<Review>
    {
        public ReviewObject()
        {
            Name = nameof(Review);
            Description = "Product review";

            Field(r => r.Timestamp).Description("Review timestamp");
            Field(r => r.Reviewer).Description("Reviewer name");
            Field(r => r.Rating).Description("Rating");
            Field(r => r.Text).Description("Review comment");
        }
    }
}