using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreWrapper;
using Newtonsoft.Json;

namespace QFWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            Users user = new Users();
            string result = user.GetManagersOfAllClients();
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> GetManagersOfClient(int id)
        {
            //return "value";
            Users user= new Users();
            string result = user.GetManagersOfClient(id);
            return result;
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
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
