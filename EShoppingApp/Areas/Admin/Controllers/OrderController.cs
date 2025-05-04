using AutoMapper;
using EShoppingApp.Entity;
using EShoppingApp.Models;
using EShoppingApp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderController(IGenericRepository<Order> orderRepository, IGenericRepository<Customer> customerRepository, IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
             _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllAsync();
          var model= _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return View(model  );
        }

        public async Task<IActionResult> Create()
        {
            var model = new OrderViewModel
            {
              Customers= _mapper.Map<List<CustomerViewModel>>( await _customerRepository.GetAllAsync()),
              Products= _mapper.Map<List<ProductViewModel>>(await _productRepository.GetAllAsync()),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            var entity = _mapper.Map<Order>(model);
            
            await _orderRepository.AddAsync(entity);
            return RedirectToAction(nameof(Index));
        }
    }
}
