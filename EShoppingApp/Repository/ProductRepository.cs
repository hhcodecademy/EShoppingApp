using EShoppingApp.Data;
using EShoppingApp.Entity;
using EShoppingApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShoppingApp.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
      
        public ProductRepository(EShoppingDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Product>> GetProductsWithCategoryAsync()
        {
            
            var products = _context.Products
                .Include(p => p.Category)
                .Where(p => !p.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
            return await products;
        }
    }
}
