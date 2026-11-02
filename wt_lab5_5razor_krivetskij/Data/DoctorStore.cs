
using System.Collections.Generic;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Data
{
    public static class DoctorStore
    {
        public static List<Doctor> Doctors { get; } = new()
        {
            new Doctor
            {
                Id = 1,
                FullName = "Убивайло Андрей Денисович",
                Specialty = "Терапевт",
                ExperienceYears = 15,
                Office = "101",
                IsActive = true
            },
            new Doctor
            {
                Id = 2,
                FullName = "Клизмович Наталья Эдуардовна",
                Specialty = "Кардиолог",
                ExperienceYears = 9,
                Office = "205",
                IsActive = true
            },
            new Doctor
            {
                Id = 3,
                FullName = "Doctor Semenov",
                Specialty = "Невролог",
                ExperienceYears = 12,
                Office = "302",
                IsActive = true
            },
            new Doctor
            {
                Id = 4,
                FullName = "Больной Павел Витальевич",
                Specialty = "Офтальмолог",
                ExperienceYears = 7,
                Office = "108",
                IsActive = true
            },
            new Doctor
            {
                Id = 5,
                FullName = "Городищенская Зоя Викторовна",
                Specialty = "Хирург",
                ExperienceYears = 20,
                Office = "410",
                IsActive = false
            }
        };
    }
}
