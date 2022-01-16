using GraphQL;
using GraphQL.Types;
using ProductReviews.Database;
using ProductReviews.GraphQL.Types;
using ProductReviews.Models;

namespace ProductReviews.GraphQL
{
    public class QueryObject : ObjectGraphType<object>
    {
        public QueryObject(IProductRepository repository)
        {
            Name = "Queries";
            Description = "The base query for all the entities in our object graph";

            FieldAsync<ProductObject, Product>(
                "product",
                "Gets a product by its unique identifier",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "The unique ID of the product"
                    }),
                context => repository.GetProductByIdAsync(context.GetArgument<int>("id")));
        }
    }
}