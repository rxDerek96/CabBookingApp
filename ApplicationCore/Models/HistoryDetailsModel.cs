
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class HistoryDetailsModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingTime { get; set; }
        public int FromPlace { get; set; }
        public int ToPlace { get; set; }
        public string PickUpAddress { get; set; }
        public string Landmark { get; set; }
        public DateTime PickupDate { get; set; }
        public string PickupTime { get; set; }
        public int CabTypeId { get; set; }
        public string ContactNo { get; set; }
        public string Status { get; set; }
        public string comp_time { get; set; }
        public decimal charge { get; set; }
        public string Feedback { get; set; }

        public CabModel Cab { get; set; }
        public PlaceModel FPlace { get; set; }
        public PlaceModel TPlace { get; set; }
    }
}
