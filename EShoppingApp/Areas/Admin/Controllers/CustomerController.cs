using AutoMapper;
using EShoppingApp.Entity;
using EShoppingApp.Models;
using EShoppingApp.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager")]
    public class CustomerController : Controller
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var datas = await _customerRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<CustomerViewModel>>(datas);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            var entity = _mapper.Map<Customer>(model);
            await _customerRepository.AddAsync(entity);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
