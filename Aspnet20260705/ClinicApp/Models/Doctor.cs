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

        [Range(0, 100_000)]
        public double Salary { get; set; }


        public List<Appointment> Appointments { get; set; } = new();
        public List<Speciality> Specialities { get; set; } = new();
    }
}
