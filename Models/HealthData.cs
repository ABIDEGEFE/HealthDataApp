using System;
using System.ComponentModel.DataAnnotations;

namespace HealthDataApp.Models
{
    public class HealthData
    {
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RecordDate { get; set; } = DateTime.Today;

        [Required]
        public string DiseaseType { get; set; }
    }
}