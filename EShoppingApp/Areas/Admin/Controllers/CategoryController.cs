using AutoMapper;
using EShoppingApp.Entity;
using EShoppingApp.Models;
using EShoppingApp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(IGenericRepository<Category> categoryRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            var entity = _mapper.Map<Category>(model);

            if (model.ImageFile != null)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }
                entity.ImageUrl = fileName;
            }

            await _categoryRepository.AddAsync(entity);
            return RedirectToAction(nameof(Index));
        }
    }
}
