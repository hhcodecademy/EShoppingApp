using EShoppingApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Components
{
    public class CalculateSalaryViewComponent: ViewComponent
    {
        private readonly IEmployeeService _employeeService;
        public CalculateSalaryViewComponent(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int empId)
        {
            var salary = await _employeeService.CalculateSalarydAsync(empId);
            if(empId % 2 == 0)
            {
                salary = salary * 2;
            }
            else
            {
                salary = salary * 3;
            }
            return View(salary);
        }
    }
}
