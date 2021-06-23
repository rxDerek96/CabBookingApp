using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ICabRepository _cabRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IHistoryRepository _historyRepository;
        private readonly IPlaceRepository _placeRepository;

        public UserService(ICabRepository cabRepository, IBookingRepository bookingRepository, IHistoryRepository historyRepository, IPlaceRepository placeRepository)
        {
            _cabRepository = cabRepository;
            _bookingRepository = bookingRepository;
            _historyRepository = historyRepository;
            _placeRepository = placeRepository;
        }
        public async Task AddBooking(BookingModel b)
        {
            var booking = new Booking
            {
                Email = b.Email,
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                FromPlace = b.FromPlace,
                ToPlace = b.ToPlace,
                PickUpAddress = b.PickUpAddress,
                Landmark = b.Landmark,
                PickupDate = b.PickupDate,
                PickupTime = b.PickupTime,
                CabTypeId = b.CabTypeId,
                ContactNo = b.ContactNo,
                Status = b.Status
            };
            await _bookingRepository.Add(booking);

        }

        public async Task AddCab(CabModel Cab)
        {
            var cab = new CabType
            {
                CabTypeName = Cab.CabTypeName
            };
            await _cabRepository.Add(cab);
        }

        public async Task AddHistory(HistoryModel h)
        {
            var history = new History
            {
                Email = h.Email,
                BookingDate = h.BookingDate,
                BookingTime = h.BookingTime,
                FromPlace = h.FromPlace,
                ToPlace = h.ToPlace,
                PickUpAddress = h.PickUpAddress,
                Landmark = h.Landmark,
                PickupDate = h.PickupDate,
                PickupTime = h.PickupTime,
                CabTypeId = h.CabTypeId,
                ContactNo = h.ContactNo,
                Status = h.Status,
                comp_time = h.comp_time,
                charge = h.charge,
                Feedback = h.Feedback
            };
            await _historyRepository.Add(history);
        }

        public async Task AddPlace(PlaceModel Place)
        {
            var place = new Place
            {
                PlaceName = Place.PlaceName
            };
            await _placeRepository.Add(place);
        }

        public async Task DeleteBooking(BookingModel b)
        {
            var booking = new Booking
            {
                Id = b.Id,
                Email = b.Email,
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                FromPlace = b.FromPlace,
                ToPlace = b.ToPlace,
                PickUpAddress = b.PickUpAddress,
                Landmark = b.Landmark,
                PickupDate = b.PickupDate,
                PickupTime = b.PickupTime,
                CabTypeId = b.CabTypeId,
                ContactNo = b.ContactNo,
                Status = b.Status
            };
            await _bookingRepository.DeletebyId(booking);
        }

        public async Task DeleteCab(CabModel Cab)
        {
            var cab = new CabType
            {
                CabTypeName = Cab.CabTypeName
            };
            await _cabRepository.DeletebyName(cab);
        }

        public async Task DeleteHistory(HistoryModel b)
        {
            var history = new History
            {
                Id = b.Id,
                Email = b.Email,
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                FromPlace = b.FromPlace,
                ToPlace = b.ToPlace,
                PickUpAddress = b.PickUpAddress,
                Landmark = b.Landmark,
                PickupDate = b.PickupDate,
                PickupTime = b.PickupTime,
                CabTypeId = b.CabTypeId,
                ContactNo = b.ContactNo,
                Status = b.Status
            };
            await _historyRepository.DeletebyId(history);
        }

        public async Task DeletePlace(PlaceModel Place)
        {
            var place = new Place
            {
                PlaceName = Place.PlaceName
            };
            await _placeRepository.DeletebyName(place);
        }

        public async Task<List<BookingModel>> ListBooking()
        {
            var bookings = await _bookingRepository.GetList();

            var bookingList = new List<BookingModel>();
            foreach (var b in bookings)
            {
                bookingList.Add(new BookingModel
                {
                    Id=b.Id,
                    Email = b.Email,
                    BookingDate=b.BookingDate,
                    BookingTime=b.BookingTime,
                    FromPlace=b.FromPlace,
                    ToPlace=b.ToPlace,
                    PickUpAddress=b.PickUpAddress,
                    Landmark=b.Landmark,
                    PickupDate=b.PickupDate,
                    PickupTime=b.PickupTime,
                    CabTypeId=b.CabTypeId,
                    ContactNo=b.ContactNo,
                    Status=b.Status
                }); ;
            }

            return bookingList;
        }

        public async Task<List<CabModel>> ListCab()
        {
            var cabs = await _cabRepository.GetList();

            var cabList = new List<CabModel>();
            foreach (var cab in cabs)
            {
                cabList.Add(new CabModel
                {
                    CabTypeId=cab.CabTypeId,
                    CabTypeName=cab.CabTypeName
                });;
            }

            return cabList;
        }

        public async Task<List<HistoryModel>> ListHistory()
        {
            var histories = await _historyRepository.GetList();

            var historyList = new List<HistoryModel>();
            foreach (var h in histories)
            {
                historyList.Add(new HistoryModel
                {
                    Id = h.Id,
                    Email = h.Email,
                    BookingDate = h.BookingDate,
                    BookingTime = h.BookingTime,
                    FromPlace = h.FromPlace,
                    ToPlace = h.ToPlace,
                    PickUpAddress = h.PickUpAddress,
                    Landmark = h.Landmark,
                    PickupDate = h.PickupDate,
                    PickupTime = h.PickupTime,
                    CabTypeId = h.CabTypeId,
                    ContactNo = h.ContactNo,
                    Status = h.Status,
                    comp_time=h.comp_time,
                    charge=h.charge,
                    Feedback=h.Feedback
                }); ;
            }

            return historyList;
        }

        public async Task<List<PlaceModel>> ListPlace()
        {
            var places = await _placeRepository.GetList();

            var placeList = new List<PlaceModel>();
            foreach (var p in places)
            {
                placeList.Add(new PlaceModel
                {
                    PlaceId = p.PlaceId,
                    PlaceName = p.PlaceName
                }); ;
            }

            return placeList;
        }

        public async Task UpdateBooking(BookingModel b)
        {
            var newbooking = new Booking
            {
                Id = b.Id,
                Email = b.Email,
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                FromPlace = b.FromPlace,
                ToPlace = b.ToPlace,
                PickUpAddress = b.PickUpAddress,
                Landmark = b.Landmark,
                PickupDate = b.PickupDate,
                PickupTime = b.PickupTime,
                CabTypeId = b.CabTypeId,
                ContactNo = b.ContactNo,
                Status = b.Status
            };

           
            await _bookingRepository.Update(newbooking);
        }

        public async Task UpdateCab(CabUpdateModel Cab)
        {
            var cabname = Cab.CabTypeName;
            var cab = await _cabRepository.GetbyName(cabname);


            cab.CabTypeName = Cab.CabTypeNewName;
            await _cabRepository.Update(cab);
        }

        public async Task UpdateHistory(HistoryModel b)
        {
            var newhistory = new History
            {
                Id = b.Id,
                Email = b.Email,
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                FromPlace = b.FromPlace,
                ToPlace = b.ToPlace,
                PickUpAddress = b.PickUpAddress,
                Landmark = b.Landmark,
                PickupDate = b.PickupDate,
                PickupTime = b.PickupTime,
                CabTypeId = b.CabTypeId,
                ContactNo = b.ContactNo,
                Status = b.Status,
                comp_time=b.comp_time,
                Feedback=b.Feedback,
                charge=b.charge
            };


            await _historyRepository.Update(newhistory);
        }

        public async Task UpdatePlace(PlaceUpdateModel Place)
        {
            var placename = Place.PlaceName;
            var place = await _placeRepository.GetbyName(placename);


            place.PlaceName = Place.PlaceNewName;
            await _placeRepository.Update(place);
        }
        public async Task<BookingDetailsModel> GetBookingDetails(int id)
        {
            var b = await _bookingRepository.GetById(id);
            var c = await _cabRepository.GetById(b.CabTypeId);
            var cab = new CabModel
            {
                CabTypeId = c.CabTypeId,
                CabTypeName = c.CabTypeName
            };
            var f =await  _placeRepository.GetById(b.FromPlace);
            var t =await _placeRepository.GetById(b.ToPlace);
            var fplace = new PlaceModel
            {
                PlaceId =f.PlaceId,
                PlaceName = f.PlaceName
            }; 
            var tplace = new PlaceModel
            {
                PlaceId = t.PlaceId,
                PlaceName = t.PlaceName
            };
            var model = new BookingDetailsModel
            {
                Id = b.Id,
                Email = b.Email,
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                FromPlace = b.FromPlace,
                ToPlace = b.ToPlace,
                PickUpAddress = b.PickUpAddress,
                Landmark = b.Landmark,
                PickupDate = b.PickupDate,
                PickupTime = b.PickupTime,
                CabTypeId = b.CabTypeId,
                ContactNo = b.ContactNo,
                Status = b.Status,
                Cab = cab,
                TPlace = tplace,
                FPlace = fplace
            };

            return model;
        }
        public async Task<HistoryDetailsModel> GetHistoryDetails(int id)
        {
            var b = await _historyRepository.GetById(id);
            var c = await _cabRepository.GetById(b.CabTypeId);
            var cab = new CabModel
            {
                CabTypeId = c.CabTypeId,
                CabTypeName = c.CabTypeName
            };
            var f = await _placeRepository.GetById(b.FromPlace);
            var t = await _placeRepository.GetById(b.ToPlace);
            var fplace = new PlaceModel
            {
                PlaceId = f.PlaceId,
                PlaceName = f.PlaceName
            };
            var tplace = new PlaceModel
            {
                PlaceId = t.PlaceId,
                PlaceName = t.PlaceName
            };
            var model = new HistoryDetailsModel
            {
                Id = b.Id,
                Email = b.Email,
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                FromPlace = b.FromPlace,
                ToPlace = b.ToPlace,
                PickUpAddress = b.PickUpAddress,
                Landmark = b.Landmark,
                PickupDate = b.PickupDate,
                PickupTime = b.PickupTime,
                CabTypeId = b.CabTypeId,
                ContactNo = b.ContactNo,
                Status = b.Status,
                Cab = cab,
                TPlace = tplace,
                FPlace = fplace,
                comp_time=b.comp_time,
                charge=b.charge,
                Feedback=b.Feedback
            };

            return model;
        }
        public async Task<List<BookingModel>> GetBookingsByCabId(int Id)
        {
            var Cab = await _cabRepository.GetCabBookingsById(Id);


            var bookings = new List<BookingModel>();

            foreach (var b in Cab.Bookings)
            {
                bookings.Add(new BookingModel
                {
                    Id = b.Id,
                    Email = b.Email,
                    BookingDate = b.BookingDate,
                    BookingTime = b.BookingTime,
                    FromPlace = b.FromPlace,
                    ToPlace = b.ToPlace,
                    PickUpAddress = b.PickUpAddress,
                    Landmark = b.Landmark,
                    PickupDate = b.PickupDate,
                    PickupTime = b.PickupTime,
                    CabTypeId = b.CabTypeId,
                    ContactNo = b.ContactNo,
                    Status = b.Status
                });
            }

            return bookings;
        }
    }
}
