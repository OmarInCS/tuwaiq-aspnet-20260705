using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {

    [Authorize]
    public class UserController : Controller {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webEnv;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment webEnv)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webEnv = webEnv;
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

            string? profilePictureUrl = null;
            if (vm.ProfilePicture != null && vm.ProfilePicture.Length > 0)
            {
                var uploadFolder = Path.Combine(_webEnv.WebRootPath, "images", "profiles");
                Directory.CreateDirectory(uploadFolder);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(vm.ProfilePicture.FileName)}";
                var filePath = Path.Combine(uploadFolder, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                vm.ProfilePicture.CopyTo(stream);

                profilePictureUrl = $"/images/profiles/{fileName}";
            }

            var user = new AppUser {
                Email = vm.Email,
                UserName = vm.Email.Split("@")[0],
                ProfilePictureUrl = profilePictureUrl,
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
