
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_krivetskij.Data;
using wt_lab8_8razor_postgresql_krivetskij.Models;

namespace wt_lab8_8razor_postgresql_krivetskij.Pages.Doctors
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctor Doctor { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var existing = await _context.Doctors
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            Doctor = existing;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != Doctor.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existing = await _context.Doctors
                .FirstOrDefaultAsync(d => d.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            existing.FullName = Doctor.FullName;
            existing.Specialty = Doctor.Specialty;
            existing.ExperienceYears = Doctor.ExperienceYears;
            existing.Office = Doctor.Office;
            existing.IsActive = Doctor.IsActive;

            await _context.SaveChangesAsync();

            return RedirectToPage("Details", new { id = existing.Id });
        }
    }
}
