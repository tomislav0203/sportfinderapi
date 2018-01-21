using System.Collections.Generic;
using System.Linq;
using Infrastructure.Domain;
using Model.DomainModels;
using SportFinderApi.Models;

namespace Repository.Repos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public City FindCity(int id)
        {
            return Session.Get<City>(id);
        }

        public IEnumerable<City> GetAllCities()
        {
            return Session.Query<City>().ToList();
        }
    }
}
