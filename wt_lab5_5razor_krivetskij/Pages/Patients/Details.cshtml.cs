
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using wt_lab5_5razor_krivetskij.Data;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Pages.Patients
{
    public class DetailsModel : PageModel
    {
        public Patient? Patient { get; private set; }

        public IActionResult OnGet(int id)
        {
            Patient = PatientStore.Patients
                .FirstOrDefault(p => p.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
