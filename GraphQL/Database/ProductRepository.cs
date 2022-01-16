using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductReviews.Models;

namespace ProductReviews.Database
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            return _context.Product.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Product> AddReviewToProductAsync(int id, Review review)
        {
            var product = await _context.Product.Where(m => m.Id == id).FirstOrDefaultAsync();

            product.AddReview(review);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}