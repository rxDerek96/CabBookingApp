using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CabUpdateModel
    {
        public int CabTypeId { get; set; }
        public string CabTypeName { get; set; }
        public string CabTypeNewName { get; set; }
    }
}