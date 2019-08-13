using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models.BankModel;
using PaymentGateway.Services.BankServices;

namespace PaymentGateway.Controllers.BankController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bank_Transaction_HistoryController : ControllerBase
    {
        private readonly BankTransactionHistoryContext _context;

        public Bank_Transaction_HistoryController(BankTransactionHistoryContext context)
        {
            _context = context;
        }

        // GET: api/Bank_Transaction_History
        [HttpGet]
        public IEnumerable<Bank_Transaction_History> GetBank_Transaction_History()
        {
            return _context.Bank_Transaction_History;
        }

        // GET: api/Bank_Transaction_History/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBank_Transaction_History([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank_Transaction_History = await _context.Bank_Transaction_History.FindAsync(id);

            if (bank_Transaction_History == null)
            {
                return NotFound();
            }

            return Ok(bank_Transaction_History);
        }

        // PUT: api/Bank_Transaction_History/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBank_Transaction_History([FromRoute] string id, [FromBody] Bank_Transaction_History bank_Transaction_History)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank_Transaction_History.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(bank_Transaction_History).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bank_Transaction_HistoryExists(id))
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

        // POST: api/Bank_Transaction_History
        [HttpPost]
        public async Task<IActionResult> PostBank_Transaction_History([FromBody] Bank_Transaction_History bank_Transaction_History)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bank_Transaction_History.Add(bank_Transaction_History);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBank_Transaction_History", new { id = bank_Transaction_History.TransactionId }, bank_Transaction_History);
        }

        // DELETE: api/Bank_Transaction_History/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank_Transaction_History([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank_Transaction_History = await _context.Bank_Transaction_History.FindAsync(id);
            if (bank_Transaction_History == null)
            {
                return NotFound();
            }

            _context.Bank_Transaction_History.Remove(bank_Transaction_History);
            await _context.SaveChangesAsync();

            return Ok(bank_Transaction_History);
        }

        private bool Bank_Transaction_HistoryExists(string id)
        {
            return _context.Bank_Transaction_History.Any(e => e.TransactionId == id);
        }
    }
}