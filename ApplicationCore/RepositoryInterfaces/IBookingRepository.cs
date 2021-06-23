using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IBookingRepository:IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetList();
        Task DeletebyId(Booking b);
    }
}
