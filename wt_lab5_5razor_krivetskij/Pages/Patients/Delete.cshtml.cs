
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_krivetskij.Data;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Pages.Patients
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Patient? Patient { get; set; }

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

        public IActionResult OnPost(int id)
        {
            if (Patient == null || Patient.Id != id)
            {
                return BadRequest();
            }

            var existing = PatientStore.Patients
                .FirstOrDefault(p => p.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            PatientStore.Patients.Remove(existing);

            return RedirectToPage("Index");
        }
    }
}
