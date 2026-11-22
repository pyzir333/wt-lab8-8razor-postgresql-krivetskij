
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_krivetskij.Data;
using wt_lab8_8razor_postgresql_krivetskij.Models;

namespace wt_lab8_8razor_postgresql_krivetskij.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Patient> Patients { get; private set; } = new();

        public List<Doctor> Doctors { get; private set; } = new();

        public async Task OnGetAsync()
        {
            Patients = await _context.Patients
                .OrderBy(p => p.Id)
                .ToListAsync();

            Doctors = await _context.Doctors
                .OrderBy(d => d.FullName)
                .ToListAsync();

            var doctorsById = Doctors.ToDictionary(d => d.Id);

            foreach (var patient in Patients)
            {
                if (doctorsById.TryGetValue(patient.DoctorId, out var doctor))
                {
                    patient.DoctorSpecialty = doctor.Specialty;
                }
            }
        }
    }
}
