using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

namespace Infrastructure.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(CabBookingAppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Booking>> GetList()
        {
            var bookings = await _dbContext.Bookings.ToListAsync();
            return bookings;
        }
        public async Task DeletebyId(Booking b)
        {
            var bid = b.Id;
            var booking = await _dbContext.Bookings.FirstOrDefaultAsync(m => m.Id == bid);
            _dbContext.Set<Booking>().Remove(booking);
            await _dbContext.SaveChangesAsync();
        }

    }
}
