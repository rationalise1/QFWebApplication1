﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreWrapper;

namespace QFWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRelationshipsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            UserRelationships userRelationships = new UserRelationships();
            string result = userRelationships.GetRelationships();
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            UserRelationships userRelationships = new UserRelationships();
            string result = userRelationships.GetRelationship(id);
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
