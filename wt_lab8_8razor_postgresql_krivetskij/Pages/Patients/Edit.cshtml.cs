
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_krivetskij.Data;
using wt_lab8_8razor_postgresql_krivetskij.Models;

namespace wt_lab8_8razor_postgresql_krivetskij.Pages.Patients
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; } = new();

        public List<Doctor> Doctors { get; private set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            await LoadDoctorsAsync();

            var existing = await _context.Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            Patient = existing;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await LoadDoctorsAsync();

            if (id != Patient.Id)
            {
                return BadRequest();
            }

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

            var existing = await _context.Patients
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            existing.FullName = Patient.FullName;
            existing.Age = Patient.Age;
            existing.DoctorId = Patient.DoctorId;
            existing.AppointmentDate = Patient.AppointmentDate;
            existing.Diagnosis = Patient.Diagnosis;
            existing.IsActive = Patient.IsActive;

            await _context.SaveChangesAsync();

            return RedirectToPage("Details", new { id = existing.Id });
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
