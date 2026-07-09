namespace ClinicApp.ViewModels {
    public class DoctorFilteredListVM {

        public List<DoctorReadVM> Doctors { get; set; } = new();

        public DoctorFilterVM Filter { get; set; } = new();
    }
}
