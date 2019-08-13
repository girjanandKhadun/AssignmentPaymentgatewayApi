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
    public class Bank_User_ClientController : ControllerBase
    {
        private readonly BankUserClientContext _context;

        public Bank_User_ClientController(BankUserClientContext context)
        {
            _context = context;
        }

        // GET: api/Bank_User_Client
        [HttpGet]
        public IEnumerable<Bank_User_Client> GetBank_User_Client()
        {
            return _context.Bank_User_Client;
        }

        // GET: api/Bank_User_Client/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBank_User_Client([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank_User_Client = await _context.Bank_User_Client.FindAsync(id);

            if (bank_User_Client == null)
            {
                return NotFound();
            }

            return Ok(bank_User_Client);
        }

        // PUT: api/Bank_User_Client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBank_User_Client([FromRoute] string id, [FromBody] Bank_User_Client bank_User_Client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank_User_Client.IdentityNumber)
            {
                return BadRequest();
            }

            _context.Entry(bank_User_Client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bank_User_ClientExists(id))
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

        // POST: api/Bank_User_Client
        [HttpPost]
        public async Task<IActionResult> PostBank_User_Client([FromBody] Bank_User_Client bank_User_Client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bank_User_Client.Add(bank_User_Client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBank_User_Client", new { id = bank_User_Client.IdentityNumber }, bank_User_Client);
        }

        // DELETE: api/Bank_User_Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank_User_Client([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank_User_Client = await _context.Bank_User_Client.FindAsync(id);
            if (bank_User_Client == null)
            {
                return NotFound();
            }

            _context.Bank_User_Client.Remove(bank_User_Client);
            await _context.SaveChangesAsync();

            return Ok(bank_User_Client);
        }

        private bool Bank_User_ClientExists(string id)
        {
            return _context.Bank_User_Client.Any(e => e.IdentityNumber == id);
        }
    }
}