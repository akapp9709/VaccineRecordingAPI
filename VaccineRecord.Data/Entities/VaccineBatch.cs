using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineRecording.Data.Entities
{
    [PrimaryKey(nameof(BatchId))]
    public class VaccineBatch
    {
        public int BatchId { get; set; }
        [ForeignKey(nameof(BatchVaccine))]
        public int VaccineId { get; set; }
        public int BatchNo { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.MinValue;

        public Vaccine? BatchVaccine { get; set; }
    }
}
