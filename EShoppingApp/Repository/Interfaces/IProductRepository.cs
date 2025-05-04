using EShoppingApp.Entity;

namespace EShoppingApp.Repository.Interfaces
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithCategoryAsync();
    }
}
