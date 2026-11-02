
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_krivetskij.Data;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Pages.Doctors
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Doctor Doctor { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var existing = DoctorStore.Doctors
                .FirstOrDefault(d => d.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            Doctor = new Doctor
            {
                Id = existing.Id,
                FullName = existing.FullName,
                Specialty = existing.Specialty,
                ExperienceYears = existing.ExperienceYears,
                Office = existing.Office,
                IsActive = existing.IsActive
            };

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (id != Doctor.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existing = DoctorStore.Doctors
                .FirstOrDefault(d => d.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            existing.FullName = Doctor.FullName;
            existing.Specialty = Doctor.Specialty;
            existing.ExperienceYears = Doctor.ExperienceYears;
            existing.Office = Doctor.Office;
            existing.IsActive = Doctor.IsActive;

            return RedirectToPage("Details", new { id = existing.Id });
        }
    }
}
