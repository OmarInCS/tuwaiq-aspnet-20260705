using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {
    public class AuthController : Controller {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Login(string ReturnUrl = "/") {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthLoginVM vm, string ReturnUrl = "/") {

            if (!ModelState.IsValid) {
                return View(vm);
            }

            var user = await _userManager.FindByEmailAsync(vm.Email);

            if (user == null) {
                ModelState.AddModelError("Email", "Email or password wrong");
                return View(vm);
            }

            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, false, false);

            if (!result.Succeeded) {
                ModelState.AddModelError("Email", "Email or password wrong");
                return View(vm);
            }

            return Redirect(ReturnUrl);
        }

        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
