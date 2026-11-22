
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_krivetskij.Data;
using wt_lab8_8razor_postgresql_krivetskij.Models;

namespace wt_lab8_8razor_postgresql_krivetskij.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Doctor> Doctors { get; private set; } = new();

        public async Task OnGetAsync()
        {
            Doctors = await _context.Doctors
                .OrderBy(d => d.Id)
                .ToListAsync();
        }
    }
}
