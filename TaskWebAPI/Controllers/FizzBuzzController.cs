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
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzRepository fizzRepository;

        public FizzBuzzController(IFizzRepository fizzRepository)
        {
            this.fizzRepository = fizzRepository;
        }

        // GET api/fizzbuzz/5
        [HttpGet("{number}")]
        public ActionResult<string> Get(int number)
        {
            var result = fizzRepository.Get(number);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}