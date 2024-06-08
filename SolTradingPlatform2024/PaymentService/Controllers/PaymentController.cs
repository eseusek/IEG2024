using Microsoft.AspNetCore.Mvc;
using PaymentService.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private static ConcurrentDictionary<int, Payment> payments = new ConcurrentDictionary<int, Payment>();
        private static int currentId = 0;

        // GET: PaymentController
        [HttpGet]
        public ActionResult<List<Payment>> Get()
        {
            return Ok(new List<Payment>(payments.Values));
        }

        // GET: PaymentController/5
        [HttpGet("{id}")]
        public ActionResult<Payment> Get(int id)
        {
            if (!payments.TryGetValue(id, out var payment))
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // POST: PaymentController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Payment payment)
        {
            var id = Interlocked.Increment(ref currentId);
            payments[id] = payment;

            return CreatedAtAction(nameof(Get), new { id = id }, payment);
        }

        // PUT: PaymentController/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Payment payment)
        {
            if (!payments.ContainsKey(id))
            {
                return NotFound();
            }

            payments[id] = payment;

            return NoContent();
        }

        // DELETE: PaymentController/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!payments.TryRemove(id, out _))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}