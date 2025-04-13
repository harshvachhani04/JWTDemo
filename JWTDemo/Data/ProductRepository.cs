using JWTDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace JWTDemo.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
    }
    public class ProductSQLRepository : IProductRepository
    {
        private readonly ILogger<ProductSQLRepository> _logger;
        private readonly AppDbContext _context;

        public ProductSQLRepository(ILogger<ProductSQLRepository> logger, AppDbContext context)
        {
            this._logger = logger;
            this._context = context;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
