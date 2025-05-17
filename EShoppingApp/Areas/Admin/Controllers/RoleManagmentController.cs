using EShoppingApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleManagmentController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleManagmentController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles?.ToList();
            var roleViewModels = roles.Select(role => new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            }).ToList();
            return View(roleViewModels);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var role = new IdentityRole
            {
                Name = model.Name
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

    
    }
}
