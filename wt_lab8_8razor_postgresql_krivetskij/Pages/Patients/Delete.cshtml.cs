
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_krivetskij.Data;
using wt_lab8_8razor_postgresql_krivetskij.Models;

namespace wt_lab8_8razor_postgresql_krivetskij.Pages.Patients
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient? Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var existing = await _context.Patients
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(existing);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
