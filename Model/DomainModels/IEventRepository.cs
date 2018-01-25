using Infrastructure.Domain;
using SportFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DomainModels
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        IEnumerable<Sport> GetAllSports();
    }
}
