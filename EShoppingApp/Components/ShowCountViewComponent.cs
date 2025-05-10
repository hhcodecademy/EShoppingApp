using EShoppingApp.Entity;
using EShoppingApp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Components
{
    public class ShowCountViewComponent : ViewComponent
    {
      
        private readonly  IGenericRepository<Employee> _employeeRepository;

        public ShowCountViewComponent(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(string domain)
        {

            var employeeCount = (await _employeeRepository.GetAllAsync()).Count();
          
            return View(employeeCount);
        }
    }
}
