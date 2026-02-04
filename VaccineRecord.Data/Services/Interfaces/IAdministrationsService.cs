using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineRecording.Data.Entities;

namespace VaccineRecording.Data.Services.Interfaces
{
    public interface IAdministrationsService
    {
        List<Administration> GetAdministrations(string from, string to);
        List<Administration> GetOverdueVaccinations(string asof);
        void InsertAdministration(Administration administration);
    }
}
