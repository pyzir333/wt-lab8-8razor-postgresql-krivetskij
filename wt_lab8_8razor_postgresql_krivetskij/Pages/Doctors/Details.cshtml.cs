
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_krivetskij.Data;
using wt_lab8_8razor_postgresql_krivetskij.Models;

namespace wt_lab8_8razor_postgresql_krivetskij.Pages.Doctors
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Doctor? Doctor { get; private set; }

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
    }
}
