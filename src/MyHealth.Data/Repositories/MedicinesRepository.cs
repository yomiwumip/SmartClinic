using SmartClinic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SmartClinic.Data.Repositories
{
    public class MedicinesRepository
    {
        SmartClinicContext _context;

        public MedicinesRepository(SmartClinicContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<Medicine> GetAsync(int tenantId, int medicineId)
        {
            return await _context.Medicines
                .Where(m => m.MedicineId == medicineId && m.TenantId == tenantId)
                .SingleOrDefaultAsync();

        }

        public async Task<Medicine> GetNextAsync(int tenantId)
        {
            return await _context.Medicines
                .Where(m => m.TenantId == tenantId)
                .FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Medicine>> GetMedicinesAsync(int tenantId, int patientId, int count)
        {
            return await _context.Medicines
                .Where(m => m.TenantId == tenantId && m.PatientId == patientId)
                .Take(count)
                .ToListAsync();
        }

    }
}
