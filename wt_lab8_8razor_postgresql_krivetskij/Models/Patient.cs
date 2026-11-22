using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace wt_lab8_8razor_postgresql_krivetskij.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ФИО пациента")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "Возраст должен быть от 1 до 120")]
        public int Age { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Выберите врача")]
        public int DoctorId { get; set; }

        [NotMapped]
        public string DoctorSpecialty { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Diagnosis { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
    }
}
