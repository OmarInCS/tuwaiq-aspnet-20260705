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


        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 3;

        public int TotalRows { get; set; }

        public int TotalPages => (int) Math.Ceiling((double) TotalRows / PageSize);
    }
}
