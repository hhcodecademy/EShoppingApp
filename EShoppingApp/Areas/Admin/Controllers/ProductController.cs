using AutoMapper;
using EShoppingApp.Entity;
using EShoppingApp.Models;
using EShoppingApp.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductRepository productRepo, IGenericRepository<Category> categoryRepo, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var datas = await _productRepo.GetProductsWithCategoryAsync();
            var model = _mapper.Map<IEnumerable<ProductViewModel>>(datas);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepo.GetAllAsync();
            var catehoryModels = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            var model = new ProductViewModel()
            {
                Categories = catehoryModels.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            var entity = _mapper.Map<Product>(model);

            if (model.ImageFiles != null)
            {
                var firstFileName = string.Empty;

                foreach (var item in model.ImageFiles)
                {
                    var fileName = Guid.NewGuid().ToString() + "_" + item.FileName;
                    if (string.IsNullOrEmpty(firstFileName))
                    {
                        firstFileName = fileName;
                    }
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }

                    var document = new ProductDocument()
                    {
                        FileName = fileName,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false,
                        FileUrl = path,

                    };
                    entity.ProductDocuments.Add(document);
                }

                entity.ImageUrl = firstFileName;
            }
            await _productRepo.AddAsync(entity);
            return RedirectToAction(nameof(Index));
        }
    }
}
