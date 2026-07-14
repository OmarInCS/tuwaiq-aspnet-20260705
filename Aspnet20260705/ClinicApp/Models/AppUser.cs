using Microsoft.AspNetCore.Identity;

namespace ClinicApp.Models {
    public class AppUser : IdentityUser {

        public string? ProfilePictureUrl { get; set; }

    }
}
