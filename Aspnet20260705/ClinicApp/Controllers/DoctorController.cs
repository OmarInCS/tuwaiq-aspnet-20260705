using ClinicApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {
    public class DoctorController : Controller {
        public IActionResult Index() {
            var doctors = Data.Doctors;
            return View(doctors);
        }

        public IActionResult Details(int id) {
            var doctor = Data.Doctors.Single(d => d.Id == id);
            return View(doctor);
        }
    }
}
