using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FootballWorld.DataLayer.Entity.Entity;
using FootballWorld.DataLayer.Repo;
using FootballWorld.Business.Logic.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FootballWorld.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IDataProvider _repo;

        public ValuesController(IDataProvider repo)
        {
            _repo = repo;
        }
        // GET: api/values
        [HttpGet]
        [Route("GetClubs")]
        public List<ClubsServiceModel> Get()
        {
            var result = _repo.GetChampionsLeagueClub();
            return result;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
