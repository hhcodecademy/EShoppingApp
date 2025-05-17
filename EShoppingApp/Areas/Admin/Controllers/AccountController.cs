using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;
using Azure.Core;
using EShoppingApp.Areas.Admin.Models;
using EShoppingApp.EmailOperations.Interfaces;
using EShoppingApp.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace EShoppingApp.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSenderOpt _emailSender;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailSenderOpt emailSender, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
            if (result.Succeeded)
            {


                return RedirectToAction("Index", "Home");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account is locked out");
                return View(model);
            }
            else if (result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Your account is not allowed");
                return View(model);
            }

            var errorMessage = "Username or password is incorrect";
            ModelState.AddModelError("", errorMessage);
            return View(model);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            var remoteIpAddress = "192.168.23.20";
            var user = new AppUser()
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                LastLoginIpAdr = remoteIpAddress

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var appUser = await _userManager.FindByNameAsync(model.Username);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                var email = appUser.Email;
                var subject = "Email Confirmation";

                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = appUser.Id, token = token }, Request.Scheme);
                var message = $"<a href='{confirmationLink}'>Click here to confirm your email</a>";
                await _emailSender.SendEmailAsync(email, subject, message);


                return RedirectToAction("SignIn");
            }
            else
            {

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View();
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {

            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Email confirmation failed");

            }
            return View("Error");
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AssignRole()
        {
            var model = new AssignRoleViewModel();
            var users = await _userManager.Users.ToListAsync();
            foreach (var user in users)
            {

                model.Users.Add(new UserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    FullName = user.UserName
                });

            }
            var roles = await _roleManager.Roles.ToListAsync();
            foreach (var role in roles)
            {
                model.Roles.Add(new RoleViewModel()
                {
                    Id = role.Id,
                    Name = role.Name
                });
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model);
            }
            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (role == null)
            {
                ModelState.AddModelError("", "Role not found");
                return View(model);
            }
            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
