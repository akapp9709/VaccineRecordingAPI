using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineRecording.Data.Entities;

namespace VaccineRecording.Data.Services.Interfaces
{
    public interface IVaccineService
    {
        List<Vaccine> GetAllVaccines();
        Vaccine GetVaccineById(int id);
        void InsertVaccine(Vaccine vaccine);
    }
}
