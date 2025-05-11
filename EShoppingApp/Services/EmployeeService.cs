using AutoMapper;
using EShoppingApp.Entity;
using EShoppingApp.Models;
using EShoppingApp.Repository.Interfaces;
using EShoppingApp.Services.Interfaces;

namespace EShoppingApp.Services
{
    public class EmployeeService:GenericService<EmployeeViewModel, Employee>, IEmployeeService
    {
      
        public EmployeeService( IMapper mapper, IGenericRepository<Employee> employeeRepository)
            : base(mapper, employeeRepository)
        {
           
        }

        public async Task<decimal> CalculateSalarydAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
            {
                return 0;
            }
            return employee.Salary;
        }
    }
}
