
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_krivetskij.Data;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Pages.Doctors
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Doctor Doctor { get; set; } = new();

        public void OnGet()
        {
            Doctor.IsActive = true;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Doctor.Id = DoctorStore.Doctors.Count == 0
                ? 1
                : DoctorStore.Doctors.Max(d => d.Id) + 1;

            DoctorStore.Doctors.Add(Doctor);

            return RedirectToPage("Index");
        }
    }
}
