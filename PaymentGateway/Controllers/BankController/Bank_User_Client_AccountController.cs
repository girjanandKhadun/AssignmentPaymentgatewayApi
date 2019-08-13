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
    public class Bank_User_Client_AccountController : ControllerBase
    {
        private readonly BankUserClientAccountContext _context;

        public Bank_User_Client_AccountController(BankUserClientAccountContext context)
        {
            _context = context;
        }

        // GET: api/Bank_User_Client_Account
        [HttpGet]
        public IEnumerable<Bank_User_Client_Account> GetBank_User_Client_Account()
        {
            return _context.Bank_User_Client_Account;
        }

        // GET: api/Bank_User_Client_Account/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBank_User_Client_Account([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank_User_Client_Account = await _context.Bank_User_Client_Account.FindAsync(id);

            if (bank_User_Client_Account == null)
            {
                return NotFound();
            }

            return Ok(bank_User_Client_Account);
        }

        // PUT: api/Bank_User_Client_Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBank_User_Client_Account([FromRoute] string id, [FromBody] Bank_User_Client_Account bank_User_Client_Account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank_User_Client_Account.AccountNumber)
            {
                return BadRequest();
            }

            _context.Entry(bank_User_Client_Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bank_User_Client_AccountExists(id))
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

        // POST: api/Bank_User_Client_Account
        [HttpPost]
        public async Task<IActionResult> PostBank_User_Client_Account([FromBody] Bank_User_Client_Account bank_User_Client_Account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bank_User_Client_Account.Add(bank_User_Client_Account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBank_User_Client_Account", new { id = bank_User_Client_Account.AccountNumber }, bank_User_Client_Account);
        }

        // DELETE: api/Bank_User_Client_Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank_User_Client_Account([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank_User_Client_Account = await _context.Bank_User_Client_Account.FindAsync(id);
            if (bank_User_Client_Account == null)
            {
                return NotFound();
            }

            _context.Bank_User_Client_Account.Remove(bank_User_Client_Account);
            await _context.SaveChangesAsync();

            return Ok(bank_User_Client_Account);
        }

        private bool Bank_User_Client_AccountExists(string id)
        {
            return _context.Bank_User_Client_Account.Any(e => e.AccountNumber == id);
        }
    }
}