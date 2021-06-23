using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PlaceUpdateModel
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string PlaceNewName { get; set; }
    }
}