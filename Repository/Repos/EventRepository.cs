using Infrastructure.Domain;
using Model.DomainModels;
using SportFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public IEnumerable<Sport> GetAllSports()
        {
            return Session.Query<Sport>();
        }
    }
}
