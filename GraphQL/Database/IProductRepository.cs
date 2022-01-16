using System.Threading.Tasks;
using ProductReviews.Models;

namespace ProductReviews.Database
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);

        Task<Product> AddReviewToProductAsync(int id, Review review);
    }
}