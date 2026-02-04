using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Repositories.Interfaces;

namespace VaccineRecording.Data.Repositories
{
    public class AdministrationsRepository : Repository<VaccineRecordingContext, Administration>, IAdministrationsRepository
    {
        public AdministrationsRepository(VaccineRecordingContext context) : base(context)
        {
        }

        public List<Administration> GetCompletedCourses(int patientId)
        {
            throw new NotImplementedException();
        }

        public DbContext GetContext()
        {
            return _context;
        }
    }
}
