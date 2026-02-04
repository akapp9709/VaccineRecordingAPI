using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineRecording.Data.Entities
{
    [PrimaryKey("PatientId")]
    public class Patient
    {
        
        public int PatientId { get; set; }
        public string NationalId { get; set; } = string.Empty;
        public string? PassportNo {  get; set; }
        public bool ForeignNational { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        [ForeignKey(nameof(PatientSex))]
        public int SexId { get; set; }
        public string? ContactNumber { get; set; }
        public string? EmailAddress { get; set; }

        public Sex? PatientSex { get; set; }
    }
}
