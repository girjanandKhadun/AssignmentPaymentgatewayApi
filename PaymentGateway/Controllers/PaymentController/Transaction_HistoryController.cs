using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models;
using PaymentGateway.Services;

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Transaction_HistoryController : ControllerBase
    {
        private readonly TransactionHistoryContext _context;

        public Transaction_HistoryController(TransactionHistoryContext context)
        {
            _context = context;
        }

        // GET: api/Transaction_History
        [HttpGet]
        public IEnumerable<Transaction_History> GetTransaction_History()
        {
            return _context.Transaction_History;
        }

        // GET: api/Transaction_History/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction_History([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction_History = await _context.Transaction_History.FindAsync(id);

            if (transaction_History == null)
            {
                return NotFound();
            }

            return Ok(transaction_History);
        }

        // PUT: api/Transaction_History/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction_History([FromRoute] int id, [FromBody] Transaction_History transaction_History)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction_History.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transaction_History).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Transaction_HistoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transaction_History
        [HttpPost]
        public async Task<IActionResult> PostTransaction_History([FromBody] Transaction_History transaction_History)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Transaction_History.Add(transaction_History);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaction_History", new { id = transaction_History.TransactionId }, transaction_History);
        }

        // DELETE: api/Transaction_History/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction_History([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction_History = await _context.Transaction_History.FindAsync(id);
            if (transaction_History == null)
            {
                return NotFound();
            }

            _context.Transaction_History.Remove(transaction_History);
            await _context.SaveChangesAsync();

            return Ok(transaction_History);
        }

        private bool Transaction_HistoryExists(int id)
        {
            return _context.Transaction_History.Any(e => e.TransactionId == id);
        }
    }
}