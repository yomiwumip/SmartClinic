using SmartClinic.Model;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SmartClinic.Data.Repositories
{
    public class TipsRepository
    {
        SmartClinicContext _context;

        public TipsRepository(SmartClinicContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<Tip> GetNextAsync(int tenantId)
        {
            return await _context.Tips
                .Where(t => t.TenantId == tenantId)
                .OrderByDescending(t => t.Date)
                .FirstOrDefaultAsync();
        }
    }
}