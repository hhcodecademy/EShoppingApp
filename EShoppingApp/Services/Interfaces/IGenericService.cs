using EShoppingApp.Entity;

namespace EShoppingApp.Services.Interfaces
{
    public interface IGenericService<TVM,TEntity> where TEntity : BaseEntity, new()
    {
        Task<TVM> GetByIdAsync(int id);
        Task<IEnumerable<TVM>> GetAllAsync();
        Task<TVM> AddAsync(TVM entity);
        Task<TVM> UpdateAsync(TVM entity);
        Task<bool> DeleteAsync(int id);
    
    }
}
