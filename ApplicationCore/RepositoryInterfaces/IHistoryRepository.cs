using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IHistoryRepository:IRepository<History>
    {
        Task<IEnumerable<History>> GetList();
        Task DeletebyId(History h);
    }
}
