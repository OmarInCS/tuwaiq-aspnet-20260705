using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {
    public class DoctorController : Controller {
        public IActionResult Index() {
            var doctors = Data.Doctors.Select(d => d.ToDoctorReadVM()).ToList();
            return View(doctors);
        }

        public IActionResult Details(int id) {
            var doctor = Data.Doctors.Single(d => d.Id == id).ToDoctorReadVM();
            return View(doctor);
        }


        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DoctorCreateVM vm) {

            if (!ModelState.IsValid) {
                return View(vm);
            }

            var doctor = vm.ToDoctor();
            doctor.Id = Data.Doctors.Max(d => d.Id) + 1;
            Data.Doctors.Add(doctor);

            return RedirectToAction(nameof(Details), new {doctor.Id});
        }

        public IActionResult Delete(int id) {
            var doctor = Data.Doctors.Single(d => d.Id == id);
            Data.Doctors.Remove(doctor);

            return NoContent();
        }
    }
}
