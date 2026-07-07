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


        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Doctor doctor) {

            if (!ModelState.IsValid) {
                return View(doctor);
            }

            doctor.Id = Data.Doctors.Max(d => d.Id) + 1;
            Data.Doctors.Add(doctor);

            return RedirectToAction(nameof(Details), new {doctor.Id});
        }
    }
}
