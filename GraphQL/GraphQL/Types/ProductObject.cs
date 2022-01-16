using GraphQL.Types;
using ProductReviews.Models;

namespace ProductReviews.GraphQL.Types
{
    public sealed class ProductObject : ObjectGraphType<Product>
    {
        public ProductObject()
        {
            Name = nameof(Product);
            Description = "Product";

            Field(m => m.Id).Description("Product ID");
            Field(m => m.Name).Description("Product name");
            Field(
                name: "Reviews",
                description: "Product reviews",
                type: typeof(ListGraphType<ReviewObject>),
                resolve: m => m.Source.Reviews);
        }
    }
}