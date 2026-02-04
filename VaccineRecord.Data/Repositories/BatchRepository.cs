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
    public class BatchRepository : Repository<VaccineRecordingContext, VaccineBatch>, IBatchRepository
    {
        public BatchRepository(VaccineRecordingContext context) : base(context)
        {

        }

        public List<VaccineBatch> GetBatchesForVaccine(int vaccineId)
        {
            List<VaccineBatch> batches = _context.VaccineBatches.Where(vb => vb.VaccineId == vaccineId).ToList();

            return batches;
        }
    }
}
