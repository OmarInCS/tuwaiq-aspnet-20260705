using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models {
    public class Appointment {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public DateTime AllocationDate { get; set; }


        public Doctor Doctor { get; set; } = null!;
    }
}
