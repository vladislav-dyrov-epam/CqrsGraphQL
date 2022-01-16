using GraphQL;
using GraphQL.Types;
using ProductReviews.Database;
using ProductReviews.GraphQL.Types;
using ProductReviews.Models;
using System;

namespace ProductReviews.GraphQL
{
    public class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(IProductRepository repository)
        {
            Name = "Mutations";
            Description = "The base mutation for all the entities in our object graph";

            FieldAsync<ProductObject, Product>(
                "addReview",
                "Add review to a product",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "The unique ID of the product"
                    },
                    new QueryArgument<NonNullGraphType<ReviewInputObject>>
                    {
                        Name = "review",
                        Description = "Review for the product"
                    }),
                context =>
                {
                    var id = context.GetArgument<int>("id");
                    var review = context.GetArgument<Review>("review");

                    review.Id = Guid.NewGuid();
                    review.Timestamp = DateTime.UtcNow;

                    return repository.AddReviewToProductAsync(id, review);
                });
        }
    }
}