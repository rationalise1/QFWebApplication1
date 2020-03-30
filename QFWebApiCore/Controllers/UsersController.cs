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
    public class UsersController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            Users user = new Users();
            string result = user.GetUsers();
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //return "value";
            Users user= new Users();
            string result = user.GetUser(id);
            return result;
        }

        [HttpGet]
        [Route("New")]
        public ActionResult<string> Get([FromHeader] string userName, string email, 
            string alias, string firstName, string lastName, string roleType )
        {
            //return "value";
            Users users = new Users();
            return users.WriteDBValues(userName, email, alias, firstName, lastName, roleType);
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
