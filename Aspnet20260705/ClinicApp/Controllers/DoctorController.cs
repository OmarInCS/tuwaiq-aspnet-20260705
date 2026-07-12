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


        public IActionResult Index(DoctorFilterVM vm) {

            var initQuery = _db.Doctors
                .Where(d => vm.Id == null || d.Id == vm.Id)
                .Where(d => vm.Name == null || d.Name.Contains(vm.Name))
                .Where(d => vm.HireDateStart == null || d.HireDate >= vm.HireDateStart)
                .Where(d => vm.HireDateEnd == null || d.HireDate <= vm.HireDateEnd);

            vm.TotalRows = initQuery.Count();

            var doctors = initQuery
                .Select(d => d.ToDoctorReadVM())
                .Skip((vm.Page - 1) * vm.PageSize)
                .Take(vm.PageSize)
                .ToList();


            return View(new DoctorFilteredListVM { Doctors = doctors, Filter = vm});
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
