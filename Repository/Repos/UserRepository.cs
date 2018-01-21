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
    }
}
