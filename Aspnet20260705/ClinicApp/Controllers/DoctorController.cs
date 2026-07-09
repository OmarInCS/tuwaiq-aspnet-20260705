using ClinicApp.Models;
using ClinicApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers {
    public class DoctorController : Controller {

        private readonly ClinicContext _db;

        public DoctorController(ClinicContext db)
        {
            _db = db;
        }


        public IActionResult Index() {
            var doctors = _db.Doctors.Select(d => d.ToDoctorReadVM()).ToList();
            return View(doctors);
        }

        public IActionResult Details(int id) {
            var doctor = _db.Doctors.Single(d => d.Id == id).ToDoctorReadVM();
            return View(doctor);
        }


        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(DoctorCreateVM vm) {

            if (!ModelState.IsValid) {
                return View(vm);
            }

            var doctor = vm.ToDoctor();
            _db.Doctors.Add(doctor);
            _db.SaveChanges();

            return RedirectToAction(nameof(Details), new {doctor.Id});
        }

        public IActionResult Delete(int id) {
            var doctor = _db.Doctors.Single(d => d.Id == id);
            _db.Doctors.Remove(doctor);
            _db.SaveChanges();

            return NoContent();
        }

        public IActionResult Update(int id) {
            var doctor = _db.Doctors.Single(d => d.Id == id).ToDoctorUpdateVM();
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, DoctorUpdateVM vm) {

            if (!ModelState.IsValid) {
                return View(vm);
            }

            var doctor = _db.Doctors.Single(d => d.Id == id);
            vm.ToDoctor(doctor);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
