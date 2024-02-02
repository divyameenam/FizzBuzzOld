using FizzBuzzAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : Controller
    {
        private readonly IFizzBuzzService _fizzBuzzService;
        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            this._fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public  IActionResult GetFizzBuzz([FromBody] string[] input)
        {
            var result = _fizzBuzzService.GetFizzBuzzResult(input);
            return Ok(new { Result = result });
        }
    }
}
