using ClinicApp.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models {
    public class ClinicContext : IdentityDbContext {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);


            //        where TUser : IdentityUser<TKey>
            //where TRole : IdentityRole<TKey>
            //where TKey : IEquatable<TKey>
            //where TUserClaim : IdentityUserClaim<TKey>
            //where TUserRole : IdentityUserRole<TKey>
            //where TUserLogin : IdentityUserLogin<TKey>
            //where TRoleClaim : IdentityRoleClaim<TKey>
            //where TUserToken : IdentityUserToken<TKey>

            modelBuilder.Entity<IdentityUser>().ToTable("Users", "auth");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "auth");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "auth");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "auth");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "auth");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "auth");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "auth");


            modelBuilder.Entity<Appointment>()
                .Property(a => a.AllocationDate)
                .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Speciality>()
                .HasMany(d => d.Doctors)
                .WithMany(s => s.Specialities)
                .UsingEntity<DoctorSpeciality>();

            modelBuilder.Entity<Doctor>()
                .HasData([
                    new Doctor {Id =1, Name= "Ahmed", Salary=20000},
                    new Doctor {Id=2, Name= "Wael", Salary=10000},
                    new Doctor {Id=3, Name= "Fahad", Salary=25000},
                    ]);

            modelBuilder.Entity<Speciality>()
                .HasData([
                        new Speciality { Id = 1, Name = "Pediatric" },
                        new Speciality { Id = 2, Name = "ENT" },
                        new Speciality { Id = 3, Name = "Cardiology" },
                        new Speciality { Id = 4, Name = "OB-Obge" },

                    ]);

            modelBuilder.Entity<DoctorSpeciality>()
                .HasData([
                        new DoctorSpeciality { DoctorId = 1, SpecialityId = 2 },
                        new DoctorSpeciality { DoctorId = 1, SpecialityId = 3 },
                        new DoctorSpeciality { DoctorId = 2, SpecialityId = 3 },
                        new DoctorSpeciality { DoctorId = 2, SpecialityId = 2 },
                    ]);


            modelBuilder.Entity<IdentityRole>()
                .HasData([
                        new IdentityRole {
                            Id = "0bc2b673-756f-426b-8434-5301c519230f",
                            Name = AppRoles.APP_ADMIN.ToString(),
                            NormalizedName = AppRoles.APP_ADMIN.ToString(),
                            ConcurrencyStamp = "0bc2b673-756f-426b-8434-5301c519230f"
                        },
                        new IdentityRole {
                            Id = "0bc2b673-756f-426b-8435-5301c519230f",
                            Name = AppRoles.DOCTOR.ToString(),
                            NormalizedName = AppRoles.DOCTOR.ToString(),
                            ConcurrencyStamp = "0bc2b673-756f-426b-8435-5301c519230f"
                        },
                        new IdentityRole {
                            Id = "0bc2b673-756f-426b-8436-5301c519230f",
                            Name = AppRoles.OFFICER.ToString(),
                            NormalizedName = AppRoles.OFFICER.ToString(),
                            ConcurrencyStamp = "0bc2b673-756f-426b-8436-5301c519230f"
                        },

                    ]);
        }
    }
}
