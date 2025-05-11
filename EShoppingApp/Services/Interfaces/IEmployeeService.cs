using EShoppingApp.Entity;
using EShoppingApp.Models;

namespace EShoppingApp.Services.Interfaces
{
    public interface IEmployeeService : IGenericService<EmployeeViewModel, Employee>
    {
        Task<decimal> CalculateSalarydAsync(int id);
    }
}
