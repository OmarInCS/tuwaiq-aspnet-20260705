using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModels {
    public class DoctorFilterVM {
        
        public int? Id { get; set; }

        public string? Name { get; set; }

        [Display(Name = "Hire Date Start")]
        public DateTime? HireDateStart { get; set; }

        [Display(Name = "Hire Date End")]
        public DateTime? HireDateEnd { get; set; }

    }
}
