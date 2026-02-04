using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineRecording.Data.Entities
{
    [PrimaryKey(nameof(LogId))]
    public class AuditLog
    {
        public int LogId { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public int EntityId {  get; set; }
        public string Action { get; set; } = string.Empty;
        [ForeignKey(nameof(AuditUser))]
        public int ChangedBy { get; set; }
        public DateTime ChangeUtc { get; set; }
        public string ChangeSummary { get; set; } = string.Empty;

        public User? AuditUser { get; set; }
    }
}
