using System;
using Challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("api/number")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        static int theNumber;
        static int tryCount;

        [HttpGet("{number}")]
        public ActionResult<NumberResult> Try(int number)
        {
            if (theNumber == 0)
                theNumber = new Random().Next(1, 50_000);

            if (tryCount == 20)
            {
                ResetNumbers();
                return BadRequest("Try again");
            }

            if (theNumber < number)
            {
                return NotFound(new NumberResult { Result = TryResult.Smaller.ToString(), Try = ++tryCount });
            }
            else if (theNumber > number)
            {
                return NotFound(new NumberResult { Result = TryResult.Bigger.ToString(), Try = ++tryCount });
            }
            else 
            {
                ResetNumbers();
                return Ok(new NumberResult { Result = TryResult.Winner.ToString(), Try = ++tryCount });
            }
        }

        static void ResetNumbers()
        {
            theNumber = tryCount = 0;
        }
    }
}
