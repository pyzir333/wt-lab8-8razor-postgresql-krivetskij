
using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_krivetskij.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ФИО врача")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите специальность")]
        [StringLength(100)]
        public string Specialty { get; set; } = string.Empty;

        [Range(0, 60, ErrorMessage = "Стаж должен быть от 0 до 60 лет")]
        public int ExperienceYears { get; set; }

        [StringLength(100)]
        public string Office { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
