using GraphQL.Types;
using ProductReviews.Models;

namespace ProductReviews.GraphQL.Types
{
    public sealed class ReviewInputObject : InputObjectGraphType<Review>
    {
        public ReviewInputObject()
        {
            Name = "ReviewInput";
            Description = "Product review";

            Field(r => r.Reviewer).Description("Reviewer name");
            Field(r => r.Rating).Description("Rating");
            Field(r => r.Text).Description("Review comment");
        }
    }
}