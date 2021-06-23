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
    public class CabRepository : Repository<CabType>, ICabRepository
    {
        public CabRepository(CabBookingAppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<CabType>> GetList()
        {
            var cabs = await _dbContext.CabTypes.ToListAsync();
            return cabs;
        }
        public async Task DeletebyName(CabType cab)
        {
            var cabname = cab.CabTypeName;
            var c = await _dbContext.CabTypes.FirstOrDefaultAsync(m => m.CabTypeName == cabname);
            _dbContext.Set<CabType>().Remove(c);
            await _dbContext.SaveChangesAsync();

        }
        public async Task<CabType> GetbyName(string cabname)
        {
            var cab = await _dbContext.CabTypes
                .FirstOrDefaultAsync(u => u.CabTypeName == cabname);
            return cab;

        }
        public async Task<CabType> GetCabBookingsById(int Id)
        {
            var c = await _dbContext.CabTypes
                .Include(g => g.Bookings)
                .FirstOrDefaultAsync(g => g.CabTypeId == Id);

            return c;
        }
    }
}
