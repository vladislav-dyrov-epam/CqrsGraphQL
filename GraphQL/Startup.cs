using GraphQL;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductReviews.Database;
using ProductReviews.GraphQL;

namespace ProductReviews
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<ProductContext>(context => { context.UseInMemoryDatabase("ProductDb"); });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddScoped<MutationObject>();
            services.AddScoped<QueryObject>();
            services.AddScoped<ProductReviewSchema>();

            services
                .AddGraphQL(
                    (options, provider) =>
                    {
                        var graphQLOptions = Configuration
                            .GetSection("GraphQL")
                            .Get<GraphQLOptions>();

                        options.ComplexityConfiguration = graphQLOptions.ComplexityConfiguration;
                        options.EnableMetrics = graphQLOptions.EnableMetrics;

                        var logger = provider.GetRequiredService<ILogger<Startup>>();

                        options.UnhandledExceptionDelegate = ctx =>
                            logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                    })
                .AddGraphTypes()
                .AddDataLoader()
                .AddSystemTextJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQL<ProductReviewSchema>();
            app.UseGraphQLAltair();
        }
    }
}