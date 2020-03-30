using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreWrapper;

namespace QFWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/roles/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //return "value";
            Roles roles = new Roles();
            return roles.ReadDBValues(id);
        }

        // GET api/roles/5
        [HttpGet]
        [Route("New")]
        public ActionResult<string> Get([FromHeader] int id, string name)
        {
            //return "value";
            Roles roles = new Roles();
            return roles.WriteDBValues(id, name);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Roles roles = new Roles();
            roles.WriteDBValues(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
