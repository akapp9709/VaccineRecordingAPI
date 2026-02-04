using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Exceptions;
using VaccineRecording.Data.Repositories.Interfaces;
using VaccineRecording.Data.Services.Interfaces;

namespace VaccineRecording.Data.Services
{
    public class BatchesService : IBatchesService
    {
        private IBatchRepository _batchRepository;

        public BatchesService(
            IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }
        public List<VaccineBatch> GetBatchesForVaccine(int vaccineId)
        {
            List<VaccineBatch> result = _batchRepository.GetBatchesForVaccine(vaccineId);

            if (!result.Any())
                throw new NotFoundException($"Batches belonging to Vaccine with ID ({vaccineId}) not found");

            return result;
        }
    }
}
