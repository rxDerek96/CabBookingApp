using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class HistoryRepository : Repository<History>, IHistoryRepository
    {
        public HistoryRepository(CabBookingAppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<History>> GetList()
        {
            var historys = await _dbContext.Historys.ToListAsync();
            return historys;
        }
        public async Task DeletebyId(History h)
        {
            var hid = h.Id;
            var history = await _dbContext.Historys.FirstOrDefaultAsync(m => m.Id == hid);
            _dbContext.Set<History>().Remove(history);
            await _dbContext.SaveChangesAsync();
        }

    }
}
