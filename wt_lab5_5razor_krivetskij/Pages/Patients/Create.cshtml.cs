
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_krivetskij.Data;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Pages.Patients
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Patient Patient { get; set; } = new();

        public System.Collections.Generic.List<Doctor> Doctors { get; private set; }
            = new();

        public void OnGet()
        {
            Patient.AppointmentDate = System.DateTime.Today;
            Patient.IsActive = true;
            LoadDoctors();
        }

        public IActionResult OnPost()
        {
            LoadDoctors();

            var doctor = DoctorStore.Doctors
                .FirstOrDefault(d => d.Id == Patient.DoctorId);

            if (doctor == null)
            {
                ModelState.AddModelError("Patient.DoctorId", "Выберите существующего врача");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Patient.Id = PatientStore.Patients.Count == 0
                ? 1
                : PatientStore.Patients.Max(p => p.Id) + 1;

            Patient.DoctorSpecialty = doctor!.Specialty;
            PatientStore.Patients.Add(Patient);

            return RedirectToPage("Index");
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
