using Infrastructure.Domain;
using SportFinderApi.Models;
using System.Collections.Generic;

namespace Model.DomainModels
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<City> GetAllCities();
        City FindCity(int id);
    }
}
