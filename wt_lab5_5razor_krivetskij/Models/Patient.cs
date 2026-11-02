
using System;
using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_krivetskij.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ФИО пациента")]
        [StringLength(100, ErrorMessage = "Максимум 100 символов")]
        public string FullName { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "Возраст должен быть от 1 до 120")]
        public int Age { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Выберите врача")]
        public int DoctorId { get; set; }

        public string DoctorSpecialty { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; } = DateTime.Today;

        public string Diagnosis { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
