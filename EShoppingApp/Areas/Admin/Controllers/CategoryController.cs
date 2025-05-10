using AutoMapper;
using EShoppingApp.Entity;
using EShoppingApp.Models;
using EShoppingApp.Repository.Interfaces;
using EShoppingApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IGenericService<CategoryViewModel, Category> _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(IMapper mapper, IWebHostEnvironment webHostEnvironment, IGenericService<CategoryViewModel, Category> categoryService)
        {
            _webHostEnvironment = webHostEnvironment;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var model = (await _categoryService.GetAllAsync()).Where(x=>x.ParentId == 0);
            return View(model);

        }
        public async Task<IActionResult> Create()
        {
            var categoryVM = new CategoryViewModel();
            var categories = (await _categoryService.GetAllAsync()).Where(x=> x.ParentId == 0);

            categoryVM.ParentCategories = categories.ToList();

            return View(categoryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (model.ImageFile != null)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }
                model.ImageUrl = fileName;
            }

            await _categoryService.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SubCategory(int parentId)
        {
            var model = (await _categoryService.GetAllAsync()).Where(x => x.ParentId == parentId);
            return View(model);
        }
    }
}
