
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_krivetskij.Data;
using wt_lab5_5razor_krivetskij.Models;


namespace wt_lab5_5razor_krivetskij.Pages.Doctors
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Doctor? Doctor { get; set; }

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

        public IActionResult OnPost(int id)
        {
            if (Doctor == null || Doctor.Id != id)
            {
                return BadRequest();
            }

            var existing = DoctorStore.Doctors
                .FirstOrDefault(d => d.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            bool hasPatients = PatientStore.Patients
     .Any(p => p.DoctorId == id);

            if (hasPatients)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Ќельз€ удалить врача, к которому прикреплены пациенты. —начала измените их записи.");

                Doctor = existing;
                return Page();
            }

            DoctorStore.Doctors.Remove(existing);

            return RedirectToPage("Index");
        }
    }
}
