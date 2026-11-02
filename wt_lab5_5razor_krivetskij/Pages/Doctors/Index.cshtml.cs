
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using wt_lab5_5razor_krivetskij.Data;
using wt_lab5_5razor_krivetskij.Models;

namespace wt_lab5_5razor_krivetskij.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        public List<Doctor> Doctors { get; private set; } = new();

        public void OnGet()
        {
            Doctors = DoctorStore.Doctors
                .OrderBy(d => d.Id)
                .ToList();
        }
    }
}
