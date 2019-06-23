using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace OpenID_poc1.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration configuration { get; set; }

        public ValuesController(IConfiguration config)
        {
            this.configuration = config;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(new { OpenId = this.configuration["Authentication:Google:ClientId"] });
        }
    }
}
