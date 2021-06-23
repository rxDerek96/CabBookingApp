using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IPlaceRepository: IRepository<Place>
    {
        Task<IEnumerable<Place>> GetList();

        Task DeletebyName(Place p);
        Task<Place> GetbyName(string pname);

    }
}
