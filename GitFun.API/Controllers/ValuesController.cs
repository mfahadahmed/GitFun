using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GitFun.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/values/5
        [HttpPost("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // // DELETE: api/values/5
        // public void Delete(int id)
        // {
        // }
    }
}