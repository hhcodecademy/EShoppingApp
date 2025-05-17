using AutoMapper;
using EShoppingApp.Entity;
using EShoppingApp.Models;
using EShoppingApp.Repository.Interfaces;
using EShoppingApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
       

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            ;
        }

        public async Task<IActionResult >Index()
        {
            var model = await _employeeService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
           var data = await _employeeService.AddAsync(employeeViewModel);
            if (data == null)
            {
                return View();
            }
            return RedirectToAction(nameof(Index));

        }

    }
}
