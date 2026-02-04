using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Exceptions;
using VaccineRecording.Data.Repositories.Interfaces;
using VaccineRecording.Data.Services.Interfaces;

namespace VaccineRecording.Data.Services
{
    public class VaccineService : IVaccineService
    {
        private IVaccineRepository _vaccineRepository;

        public VaccineService(
            IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public List<Vaccine> GetAllVaccines()
        {
            List<Vaccine> result = _vaccineRepository.GetAll();
            return result;
        }

        public Vaccine GetVaccineById(int id)
        {
            Vaccine? result = _vaccineRepository.GetSingle(id);

            if (result == null)
                throw new NotFoundException($"Vaccine with ID ({id}) not found.");

            return result;
        }

        public void InsertVaccine(Vaccine vaccine)
        {
            _vaccineRepository.Insert(vaccine);
        }
    }
}
