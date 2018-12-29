using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskWebAPI.Repository;

namespace TaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockyController : ControllerBase
    {
        private readonly IMockyRepository mockyRepository;

        public MockyController(IMockyRepository mockyRepository)
        {
            this.mockyRepository = mockyRepository;
        }

        [HttpGet]
        public ActionResult<string> Mocky()
        {
            var result = mockyRepository.GetMocky();

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}