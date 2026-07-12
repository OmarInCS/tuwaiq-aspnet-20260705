using ClinicApp.Helpers;
using ClinicApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModels {
    public class DoctorUpdateVM {
        
        [MaxLength(100)]
        public string Name { get; set; }

        [NotFutureDate(ErrorMessage = "Hiredate can't be a furture date")]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; } = DateTime.Now;

        [Range(0, 100_000)]
        public double Salary { get; set; }

        public List<int> SelectedSpecialityIds { get; set; } = new();

        public List<SpecialityReadVM> AllSpecialities { get; set; } = new();


        public void ToDoctor(Doctor doctor) {
            doctor.Name = Name;
            doctor.HireDate = HireDate;
            doctor.Salary = Salary;
        }
    }
}
