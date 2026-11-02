
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_krivetskij.Data;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Pages.Patients
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Patient Patient { get; set; } = new();

        public List<Doctor> Doctors { get; private set; } = new();

        public IActionResult OnGet(int id)
        {
            LoadDoctors();

            var existing = PatientStore.Patients
                .FirstOrDefault(p => p.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            Patient = new Patient
            {
                Id = existing.Id,
                FullName = existing.FullName,
                Age = existing.Age,
                DoctorId = existing.DoctorId,
                DoctorSpecialty = existing.DoctorSpecialty,
                AppointmentDate = existing.AppointmentDate,
                Diagnosis = existing.Diagnosis,
                IsActive = existing.IsActive
            };

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            LoadDoctors();

            if (id != Patient.Id)
            {
                return BadRequest();
            }

            var doctor = DoctorStore.Doctors
                .FirstOrDefault(d => d.Id == Patient.DoctorId && d.IsActive);

            if (doctor == null)
            {
                ModelState.AddModelError(
                    "Patient.DoctorId",
                    "¬ыберите существующего активного врача");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existing = PatientStore.Patients
                .FirstOrDefault(p => p.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            existing.FullName = Patient.FullName;
            existing.Age = Patient.Age;
            existing.DoctorId = Patient.DoctorId;
            existing.DoctorSpecialty = doctor!.Specialty;
            existing.AppointmentDate = Patient.AppointmentDate;
            existing.Diagnosis = Patient.Diagnosis;
            existing.IsActive = Patient.IsActive;

            return RedirectToPage("Details", new { id = existing.Id });
        }

        private void LoadDoctors()
        {
            Doctors = DoctorStore.Doctors
                .Where(d => d.IsActive)
                .OrderBy(d => d.FullName)
                .ToList();
        }
    }
}
