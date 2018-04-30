using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace WebApiPracticeApp.Controllers
{
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        [HttpGet]
        [Route("one")]
        public IHttpActionResult FetchOneEmployees()
        {
            return Ok("ONE employee was returned");
        }

        [Authorize]
        [HttpGet]
        [Route("some")]
        public IHttpActionResult FetchSomeEmployees()
        {
            var username = User.Identity.Name;

            return Ok("SOME employees were returned for authenticated user " + username);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("all")]
        public IHttpActionResult FetchAllEmployees()
        {
            var identity = (ClaimsIdentity) User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(r => r.Value);

            return Ok("ALL employees were returned for authorized user " + identity.Name + " with roles: " + string.Join(",", roles.ToList()));
        }
    }
}
