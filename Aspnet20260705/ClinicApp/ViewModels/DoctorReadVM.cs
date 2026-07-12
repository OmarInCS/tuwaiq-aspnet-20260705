using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModels {
    public class DoctorReadVM {
        
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime HireDate { get; set; }

        [Range(0, 100_000)]
        public double Salary { get; set; }

        public List<SpecialityReadVM> Specialities { get; set; } = new();

        public int YearsOfService => (int) ((DateTime.Now - HireDate).TotalDays / 365);

        public string FormattedHireDate => HireDate.ToString("dd-MMM-yyyy");
    }
}
