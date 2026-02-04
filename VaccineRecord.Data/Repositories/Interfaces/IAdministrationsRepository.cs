using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineRecording.Data.Entities;

namespace VaccineRecording.Data.Repositories.Interfaces
{
    public interface IAdministrationsRepository : IRepository<Administration>
    {
        List<Administration> GetCompletedCourses(int patientId);
        DbContext GetContext();
    }
}
