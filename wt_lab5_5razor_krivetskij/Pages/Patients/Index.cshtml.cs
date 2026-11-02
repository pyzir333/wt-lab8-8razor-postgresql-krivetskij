
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using wt_lab5_5razor_krivetskij.Data;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Pages.Patients
{
    public class IndexModel : PageModel
    {
        public List<Patient> Patients { get; private set; } = new();

        public System.Collections.Generic.List<wt_lab5_5razor_krivetskij.Models.Doctor> Doctors
        { get; private set; } = new();

        public void OnGet()
        {
            Patients = PatientStore.Patients
                .OrderBy(p => p.Id)
                .ToList();

            Doctors = wt_lab5_5razor_krivetskij.Data.DoctorStore.Doctors
                .OrderBy(d => d.FullName)
                .ToList();
        }

    }
}
