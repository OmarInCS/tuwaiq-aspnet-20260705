using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {

    [Authorize]
    public class UserController : Controller {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index() {
            return View();
        }

        [Authorize(Roles = "APP_ADMIN")]
        public IActionResult Add() {
            return View();
        }

        [Authorize(Roles = "APP_ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(UserCreateVM vm) {

            if (!ModelState.IsValid) {
                return View(vm);
            }

            var user = new IdentityUser {
                Email = vm.Email,
                UserName = vm.Email.Split("@")[0],
            };

            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded) {
                ModelState.AddModelError("Email", "Create user failed");
                return View(vm);
            }

            result = await _userManager.AddToRoleAsync(user, vm.Role);
            if (!result.Succeeded) {
                ModelState.AddModelError("Email", "Assign Role failed");
                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
