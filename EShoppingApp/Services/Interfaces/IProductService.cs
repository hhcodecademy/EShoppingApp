using EShoppingApp.Models;

namespace EShoppingApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewModel> GetByIdAsync(int id);
        Task<IEnumerable<ProductViewModel>> GetAllAsync();
        Task<ProductViewModel> AddAsync(ProductViewModel entity);
        Task<ProductViewModel> UpdateAsync(ProductViewModel entity);
        Task<bool> DeleteAsync(int id);
    }
}
