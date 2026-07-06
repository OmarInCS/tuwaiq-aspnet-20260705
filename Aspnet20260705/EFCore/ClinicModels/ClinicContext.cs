using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    public class ClinicContext : DbContext {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Speciality> Specialities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=DESKTOP-2F5GL4L;Database=Clinic;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

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

        }
    }
}
