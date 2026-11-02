
using System;
using System.Collections.Generic;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Data
{
    public static class PatientStore
    {
        public static List<Patient> Patients { get; } = new()
        {
            new Patient
            {
                Id = 1,
                FullName = "Денисенко Даниил Денисович",
                Age = 35,
                DoctorId = 1,
                DoctorSpecialty = "Терапевт",
                AppointmentDate = new DateTime(2026, 10, 26),
                Diagnosis = "Диарея",
                IsActive = true
            },
            new Patient
            {
                Id = 2,
                FullName = "Кобзева Виктория Юрьевна",
                Age = 28,
                DoctorId = 2,
                DoctorSpecialty = "Кардиолог",
                AppointmentDate = new DateTime(2026, 10, 27),
                Diagnosis = "Плановый осмотр",
                IsActive = true
            },
            new Patient
            {
                Id = 3,
                FullName = "Жизневская Екатерина Андреевна",
                Age = 42,
                DoctorId = 3,
                DoctorSpecialty = "Невролог",
                AppointmentDate = new DateTime(2026, 10, 28),
                Diagnosis = "Мигрень",
                IsActive = true
            },
            new Patient
            {
                Id = 4,
                FullName = "Круталевич Дарья Андреевна",
                Age = 31,
                DoctorId = 5,
                DoctorSpecialty = "Офтальмолог",
                AppointmentDate = new DateTime(2026, 10, 29),
                Diagnosis = "Проверка зрения",
                IsActive = false
            },
            new Patient
            {
                Id = 5,
                FullName = "Осташевская Дарья Андреевна",
                Age = 50,
                DoctorId = 5,
                DoctorSpecialty = "Хирург",
                AppointmentDate = new DateTime(2026, 10, 30),
                Diagnosis = "Консультация",
                IsActive = true
            }
        };
    }
}
