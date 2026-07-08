using ClinicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models {
    public class Doctor {
        
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime HireDate { get; set; }

        public double Salary { get; set; }


        public List<Appointment> Appointments { get; set; } = new();
        public List<Speciality> Specialities { get; set; } = new();


        public DoctorReadVM ToDoctorReadVM() {
            return new DoctorReadVM {
                Id = Id,
                Name = Name,
                HireDate = HireDate,
                Salary = Salary,
            };
        }

        public DoctorUpdateVM ToDoctorUpdateVM() {
            return new DoctorUpdateVM {
                Name = Name,
                HireDate = HireDate,
                Salary = Salary,
            };
        }
    }
}
