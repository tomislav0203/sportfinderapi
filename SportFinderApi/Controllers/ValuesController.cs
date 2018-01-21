using Model.DomainModels;
using Repository.Configuration;
using Repository.Repos;
using SportFinderApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SportFinderApi.Controllers
{
    public class ValuesController : ApiController
    {
        private IUserRepository _userRepo;

        public ValuesController(IUserRepository repository)
        {
            _userRepo = repository;
        }

        // GET api/values
        public User Get()
        {
            User user;
            user = _userRepo.GetById(1);
            return user;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
