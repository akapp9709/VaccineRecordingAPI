using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineRecording.Data.Entities
{
    [PrimaryKey(nameof(FacilityId))]
    public class Facility
    {
        public int FacilityId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
