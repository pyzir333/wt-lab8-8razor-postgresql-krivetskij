
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_krivetskij.Data;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Pages.Doctors
{
    public class DetailsModel : PageModel
    {
        public Doctor? Doctor { get; private set; }

        public IActionResult OnGet(int id)
        {
            Doctor = DoctorStore.Doctors
                .FirstOrDefault(d => d.Id == id);

            if (Doctor == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
