
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_krivetskij.Data;
using wt_lab8_8razor_postgresql_krivetskij.Models;

namespace wt_lab8_8razor_postgresql_krivetskij.Pages.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Patient? Patient { get; private set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(d => d.Id == Patient.DoctorId);

            Patient.DoctorSpecialty = doctor?.Specialty ?? "Не указан";

            return Page();
        }
    }
}
