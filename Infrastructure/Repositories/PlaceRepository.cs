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
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(CabBookingAppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Place>> GetList()
        {
            var places = await _dbContext.Places.ToListAsync();
            return places;
        }
        public async Task DeletebyName(Place place)
        {
            var placename = place.PlaceName;
            var p = await _dbContext.Places.FirstOrDefaultAsync(m => m.PlaceName == placename);
            _dbContext.Set<Place>().Remove(p);
            await _dbContext.SaveChangesAsync();

        }
        public async Task<Place> GetbyName(string placename)
        {
            var place = await _dbContext.Places
                .FirstOrDefaultAsync(u => u.PlaceName == placename);
            return place;
        }
        
    }
}
