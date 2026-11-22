
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_krivetskij.Data;
using wt_lab8_8razor_postgresql_krivetskij.Models;

namespace wt_lab8_8razor_postgresql_krivetskij.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; } = new();

        public List<Doctor> Doctors { get; private set; } = new();

        public async Task OnGetAsync()
        {
            Patient.AppointmentDate = DateTime.Today;
            Patient.IsActive = true;

            await LoadDoctorsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await LoadDoctorsAsync();

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(d =>
                    d.Id == Patient.DoctorId && d.IsActive);

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

            Patient.AppointmentDate = DateTime.SpecifyKind(
    Patient.AppointmentDate,
    DateTimeKind.Utc);

            Patient.CreatedAt = DateTime.UtcNow;
            Patient.DoctorSpecialty = doctor!.Specialty;

            _context.Patients.Add(Patient);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        private async Task LoadDoctorsAsync()
        {
            Doctors = await _context.Doctors
                .Where(d => d.IsActive)
                .OrderBy(d => d.FullName)
                .ToListAsync();
        }
    }
}
