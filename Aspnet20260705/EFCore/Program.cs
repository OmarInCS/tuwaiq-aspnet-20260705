// See https://aka.ms/new-console-template for more information
using EFCore.ClinicModels;
using EFCore.HrModels;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//var db = new HrContext();

//var numOfEmps = db.Employees.Count();

//var empKing = db.Employees.Where(e => e.LastName == "King").First();

//Console.WriteLine($"#Employees: {numOfEmps}");
//Console.WriteLine(empKing.Salary);


var db = new ClinicContext();

//var d1 = new Doctor {
//    Name = "Belal",
//    HireDate = DateTime.Now,
//    Salary = 30000
//};

//db.Doctors.Add(d1);
//db.SaveChanges();

var a1 = new Appointment {
    DoctorId = 3,
    PatientId = 3,
};

db.Appointments.Add(a1);
db.SaveChanges();


// LINQ

//var d1 = db.Doctors.ToList();
////Console.WriteLine(d1.Salary);
//foreach (var d in d1) {
//    d.HireDate = DateTime.Now;
//    d.Specialities = new List<Speciality> {
//        new Speciality { Name = "Pediatric"},
//        new Speciality { Name = "Cardio"}
//    };
//}
//db.SaveChanges();


//db.Doctors.Remove(d1);
//db.SaveChanges();


//var d1 = db.Doctors.First(d => d.Salary > 5000);
//Console.WriteLine(d1.Name);

var doctorBelow30 = db.Doctors
    .Include(d => d.Specialities)
    //.Where(d => d.Salary < 30000)
    .OrderByDescending(d => d.Name)
    .Select(d => new {
        Name = d.Name,
        Salary = d.Salary,
        MainSpeciality = d.Specialities.First().Name,
    })
    .Take(3)
    .ToList();

foreach (var doctor in doctorBelow30)
{
    Console.WriteLine(doctor.Name);
    Console.WriteLine(doctor.MainSpeciality);
}


var docApptCount = db.Appointments
    .AsNoTracking()
    .Include(d => d.Doctor)
    .GroupBy(d => d.Doctor.Name)
    .Select(d => new {
        Doctor = d.Key,
        NumOfAppt = d.Count()
    });

foreach (var d in docApptCount)
{
    Console.WriteLine($"{d.Doctor}: {d.NumOfAppt}");
}



