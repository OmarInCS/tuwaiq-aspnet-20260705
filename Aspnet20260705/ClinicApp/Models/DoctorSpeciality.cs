//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models {

    [Table("DoctorSpecialities")]
    //[PrimaryKey(nameof(DoctorId), nameof(SpecialityId))]
    public class DoctorSpeciality {
        public int DoctorId { get; set; }
        public int SpecialityId { get; set; }


    }
}
