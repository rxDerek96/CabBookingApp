using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task AddPlace(PlaceModel Place);
        Task UpdatePlace(PlaceUpdateModel Place);
        Task DeletePlace(PlaceModel Place);
        Task<List<PlaceModel>> ListPlace();

        Task AddCab(CabModel Cab);
        Task UpdateCab(CabUpdateModel Cab);
        Task DeleteCab(CabModel Place);
        Task<List<CabModel>> ListCab();

        Task AddHistory(HistoryModel History);
        Task UpdateHistory(HistoryModel History);
        Task DeleteHistory(HistoryModel History);
        Task<List<HistoryModel>> ListHistory();

        Task AddBooking(BookingModel Booking);
        Task UpdateBooking(BookingModel Booking);
        Task DeleteBooking(BookingModel Booking);
        Task<List<BookingModel>> ListBooking();
        Task<BookingDetailsModel> GetBookingDetails(int id);
        Task<HistoryDetailsModel> GetHistoryDetails(int id);
        Task<List<BookingModel>> GetBookingsByCabId(int id);

    }
}
