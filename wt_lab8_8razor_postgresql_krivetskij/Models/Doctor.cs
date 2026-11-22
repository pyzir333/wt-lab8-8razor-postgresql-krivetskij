
using System.ComponentModel.DataAnnotations;

namespace wt_lab8_8razor_postgresql_krivetskij.Models
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

        [Range(0, 70, ErrorMessage = "Стаж должен быть от 0 до 70 лет")]
        public int ExperienceYears { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Укажите кабинет")]
        public int Office { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
