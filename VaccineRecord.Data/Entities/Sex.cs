using Microsoft.EntityFrameworkCore;

namespace VaccineRecording.Data.Entities
{
    //Needs Initial Data
    [PrimaryKey("SexId")]
    public class Sex
    {
        public int SexId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
