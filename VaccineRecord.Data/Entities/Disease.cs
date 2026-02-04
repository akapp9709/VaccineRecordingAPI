using Microsoft.EntityFrameworkCore;

namespace VaccineRecording.Data.Entities
{
    [PrimaryKey("DiseaseId")]
    public class Disease
    {
        public int DiseaseId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
