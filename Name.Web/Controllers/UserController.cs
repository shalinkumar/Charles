using Businesslogic.ServiceContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Name.Web.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        private readonly IServiceContainer _serviceContainer;

        public UserController(IServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet, Route("login/{userName}")]
        public bool ValidateApplicationUser(string userName)
        {

            return this._serviceContainer.ValidateApplicationUser(userName, "");

        }

        // GET api/values/5
        [HttpGet]
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
