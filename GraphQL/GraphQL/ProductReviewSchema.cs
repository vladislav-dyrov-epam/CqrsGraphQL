using System;
using GraphQL.Types;

namespace ProductReviews.GraphQL
{
    public class ProductReviewSchema : Schema
    {
        public ProductReviewSchema(QueryObject query, MutationObject mutation, IServiceProvider sp) : base(sp)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}