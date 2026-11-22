
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_krivetskij.Data;
using wt_lab8_8razor_postgresql_krivetskij.Models;

namespace wt_lab8_8razor_postgresql_krivetskij.Pages.Doctors
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctor? Doctor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Doctor = await _context.Doctors
                .FirstOrDefaultAsync(d => d.Id == id);

            if (Doctor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var existing = await _context.Doctors
                .FirstOrDefaultAsync(d => d.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            bool hasPatients = await _context.Patients
                .AnyAsync(p => p.DoctorId == id);

            if (hasPatients)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Ќельз€ удалить врача, к которому прикреплены пациенты. —начала измените их записи.");

                Doctor = existing;
                return Page();
            }

            _context.Doctors.Remove(existing);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
