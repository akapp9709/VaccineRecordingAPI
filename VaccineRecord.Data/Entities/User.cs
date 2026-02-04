using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineRecording.Data.Entities
{
    [PrimaryKey(nameof(UserId))]
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
