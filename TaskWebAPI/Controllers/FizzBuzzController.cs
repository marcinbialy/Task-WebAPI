using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskWebAPI.Methods;

namespace TaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzz fizz;

        public FizzBuzzController(IFizzBuzz fizz)
        {
            this.fizz = fizz;
        }

        // GET api/fizzbuzz/5
        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            var result = fizz.Get(number);

            if (String.IsNullOrEmpty(result))
            {
                return NotFound();
            }
                
            return Ok(result);
        }
    }
}