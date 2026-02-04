using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineRecording.Data.Entities
{
    [PrimaryKey("VaccineId")]
    public class Vaccine
    {
        public int VaccineId { get; set; }
        public string VaccineName { get; set; } = string.Empty;
        [ForeignKey(nameof(VaccineManufacturer))]
        public int? ManufacturerId { get; set; }
        [ForeignKey(nameof(TargetedDisease))]
        public int DiseaseId { get; set; }
        public int DosesRequired { get; set; }
        public int? DoseIntervalDays { get; set; }

        public Manufacturer? VaccineManufacturer { get; set; }
        public Disease? TargetedDisease { get; set; }
        public ICollection<VaccineBatch> VaccineBatches { get; set; } = new List<VaccineBatch>();

    }
}
