using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskWebAPI.Methods;

namespace TaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockyController : ControllerBase
    {
        private readonly IMocky mocky;

        public MockyController(IMocky mocky)
        {
            this.mocky = mocky;
        }

        [HttpGet]
        public IActionResult Mocky()
        {
            try
            {
                var result = mocky.GetMocky("http://www.mocky.io/v2/5c127054330000e133998f85");

                if (String.IsNullOrEmpty(result))
                {
                    return NotFound();
                }
                
                return Ok(result);
            }
            catch (WebException)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}