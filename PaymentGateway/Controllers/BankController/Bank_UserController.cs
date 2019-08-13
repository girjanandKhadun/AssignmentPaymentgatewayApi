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
    public class Bank_UserController : ControllerBase
    {
        private readonly BankUserContext _context;

        public Bank_UserController(BankUserContext context)
        {
            _context = context;
        }

        // GET: api/Bank_User
        [HttpGet]
        public IEnumerable<Bank_User> GetBank_User()
        {
            return _context.Bank_User;
        }

        // GET: api/Bank_User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBank_User([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank_User = await _context.Bank_User.FindAsync(id);

            if (bank_User == null)
            {
                return NotFound();
            }

            return Ok(bank_User);
        }

        // PUT: api/Bank_User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBank_User([FromRoute] int id, [FromBody] Bank_User bank_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank_User.userId)
            {
                return BadRequest();
            }

            _context.Entry(bank_User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bank_UserExists(id))
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

        // POST: api/Bank_User
        [HttpPost]
        public async Task<IActionResult> PostBank_User([FromBody] Bank_User bank_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bank_User.Add(bank_User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBank_User", new { id = bank_User.userId }, bank_User);
        }

        // DELETE: api/Bank_User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank_User([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank_User = await _context.Bank_User.FindAsync(id);
            if (bank_User == null)
            {
                return NotFound();
            }

            _context.Bank_User.Remove(bank_User);
            await _context.SaveChangesAsync();

            return Ok(bank_User);
        }

        private bool Bank_UserExists(int id)
        {
            return _context.Bank_User.Any(e => e.userId == id);
        }
    }
}