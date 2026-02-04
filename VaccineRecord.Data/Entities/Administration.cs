using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineRecording.Data.Entities
{
    [PrimaryKey(nameof(AdministrationId))]
    public class Administration
    {
        public int AdministrationId { get; set; }
        [ForeignKey(nameof(AdministrationPatient))]
        public int PatientId { get; set; }
        [ForeignKey(nameof(AdministrationVaccine))]
        public int VaccineId { get; set; }
        [ForeignKey(nameof(AdministrationVaccineBatch))]
        public int? BatchId { get; set; }
        public int DoseNo { get; set; }
        public DateTime AdministeredOn { get; set; }
        [ForeignKey(nameof(AdministrationUser))]
        public int AdministeredBy { get; set; }
        [ForeignKey(nameof(AdministrationFacility))]
        public int FacilityId { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }


        public Patient? AdministrationPatient { get; set; }
        public Vaccine? AdministrationVaccine { get; set; }
        public VaccineBatch? AdministrationVaccineBatch { get; set; }
        public User? AdministrationUser { get; set; }
        public Facility? AdministrationFacility { get; set; }

    }
}
