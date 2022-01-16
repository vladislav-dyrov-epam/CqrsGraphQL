# CQRS and GraphQL

## How to launch locally
Once downloaded/cloned, open the solution file located in the root. It consists of a single project (ProductReviews) that maintains an in-memory, SQL-like database with products and reviews, and GraphQL endpoints.

After installing NuGet packages and rebuilding the project, launch and navigate to `%hostname%/ui/altair` endpoint. The client IDE will then be opened; this enables you to interact with the GraphQL server running in the background.

Once Altair is loaded, please insert the query as follows into the Query pane:
```
query {
  product(id: 1) {
    id
    name
    reviews {
      timestamp
      reviewer
      rating
      text
    }
  }
}
```
And press 'Run query'. The server's response will be visualized on the Result pane. Now let's add a new review. Insert this mutation into the Query pane:
```
mutation addReview($review: ReviewInput!) {
  addReview(id: 2, review: $review) {
    id
    name
    reviews {
      reviewer
      rating
      text
    }
  }
}
```
Expand the Variables pane under the Query, and insert the input as follows:
```
{
  "review": {
    "reviewer": "User",
    "rating": 5,
    "text": "Best in class"
  }
}
```
Then press 'Run mutation addReview' to see the modified object in return.

## Home task
### Learn CQRS and GraphQL fundamentals
Check out the materials in the sections below, explore this example. If necessary, ask your mentor for help in understanding.
### Enable GraphQL in the 'Reviews' feature
Extend the primary service (upon the example provided) with GraphQL endpoint to fetch and create reviews. Remove existing REST endpoints that handle reviews. Remember that the reviews are stored in MongoDB, not in the SQL database as in the example.
### Apply CQRS pattern in the 'Reviews' feature
Now that you have enabled queries and mutations supported by GraphQL, and established communication between the primary service and the 'Reviews' microservice, you need to fully isolate Commands and Queries. One of the common practices is separating read and write stores with two databases physically and ensuring eventual consistency between them.

![CQRS](https://raw.githubusercontent.com/vladislav-dyrov-epam/CqrsGraphQL/main/CQRS.png)

This way, if the application is read-intensive, which means reading more than writing, a developer can define custom, query-optimized data schemas.

Please refactor the 'Reviews' microservice so that new reviews appear in both data storages. To achieve this, you'll need to create a new table in your primary, persistent storage (SQL). Also, please optimize the record schema in your read storage (MongoDB) so that all reviews about one product are attached to one 'product' document. Therefore, you avoid full scanning when gathering reviews about the product requested. Make sure that in the primary service you fetch reviews from the read storage, and data models are aligned with the optimized schema.

## Additional reading
- CQRS: https://martinfowler.com/bliki/CQRS.html
- Introduction to GraphQL: https://graphql.org/learn/
- GraphQL engine for .NET: https://graphql-dotnet.github.io/

## Additional lectures (videos)
- GraphQL: The Big Picture: https://www.pluralsight.com/courses/graphql-big-picture
- Intro to GraphQL, Part 1: What is GraphQL: https://docs.microsoft.com/en-us/shows/graphql/intro-to-graphql-part-1
- Intro to GraphQL, Part 2: Exploring a GraphQL Endpoint: https://docs.microsoft.com/en-us/shows/graphql/intro-to-graphql-part-2
- Creating a GraphQL Backend: https://docs.microsoft.com/en-us/shows/on-net/creating-a-graphql-backend
