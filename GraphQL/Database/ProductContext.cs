using Microsoft.EntityFrameworkCore;
using ProductReviews.Models;
using System;

namespace ProductReviews.Database
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().OwnsMany(m => m.Reviews).HasData(
                new Review
                {
                    Id = Guid.NewGuid(),
                    Reviewer = "A",
                    Rating = 4,
                    Text = "Fine",
                    ProductId = 1
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    Reviewer = "B",
                    Rating = 5,
                    Text = "Worth to buy",
                    ProductId = 1
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    Reviewer = "C",
                    Rating = 1,
                    Text = "The worst possible",
                    ProductId = 2
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    Reviewer = "D",
                    Rating = 3,
                    Text = "Could have been better",
                    ProductId = 2
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Chai"
                },
                new Product
                {
                    Id = 2,
                    Name = "Chang"
                }
            );
        }
    }
}