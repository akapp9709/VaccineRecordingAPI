using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineRecording.Data.Entities;
using VaccineRecording.Data.Repositories.Interfaces;

namespace VaccineRecording.Data.Repositories
{
    public class VaccineRepository : Repository<VaccineRecordingContext, Vaccine>, IVaccineRepository
    {
        public VaccineRepository(VaccineRecordingContext context) : base(context)
        {
        }

        public void UpsertVaccines(List<Vaccine> vaccines)
        {
            foreach(Vaccine vaccine in vaccines)
            {
                if (GetSingle<int>(vaccine.VaccineId) == null)
                    Insert(vaccine);
                else
                    Update(vaccine);
            }
        }
    }
}
