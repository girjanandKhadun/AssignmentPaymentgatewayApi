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
    public class Bank_User_Client_Card_InfoController : ControllerBase
    {
        private readonly BankUserClientCardInfoContext _context;

        public Bank_User_Client_Card_InfoController(BankUserClientCardInfoContext context)
        {
            _context = context;
        }

        // GET: api/Bank_User_Client_Card_Info
        [HttpGet]
        public IEnumerable<Bank_User_Client_Card_Info> GetBank_User_Client_Card_Info()
        {
            return _context.Bank_User_Client_Card_Info;
        }

        // GET: api/Bank_User_Client_Card_Info/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBank_User_Client_Card_Info([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank_User_Client_Card_Info = await _context.Bank_User_Client_Card_Info.FindAsync(id);

            if (bank_User_Client_Card_Info == null)
            {
                return NotFound();
            }

            return Ok(bank_User_Client_Card_Info);
        }

        // PUT: api/Bank_User_Client_Card_Info/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBank_User_Client_Card_Info([FromRoute] string id, [FromBody] Bank_User_Client_Card_Info bank_User_Client_Card_Info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank_User_Client_Card_Info.CardNumber)
            {
                return BadRequest();
            }

            _context.Entry(bank_User_Client_Card_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bank_User_Client_Card_InfoExists(id))
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

        // POST: api/Bank_User_Client_Card_Info
        [HttpPost]
        public async Task<IActionResult> PostBank_User_Client_Card_Info([FromBody] Bank_User_Client_Card_Info bank_User_Client_Card_Info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bank_User_Client_Card_Info.Add(bank_User_Client_Card_Info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBank_User_Client_Card_Info", new { id = bank_User_Client_Card_Info.CardNumber }, bank_User_Client_Card_Info);
        }

        // DELETE: api/Bank_User_Client_Card_Info/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank_User_Client_Card_Info([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank_User_Client_Card_Info = await _context.Bank_User_Client_Card_Info.FindAsync(id);
            if (bank_User_Client_Card_Info == null)
            {
                return NotFound();
            }

            _context.Bank_User_Client_Card_Info.Remove(bank_User_Client_Card_Info);
            await _context.SaveChangesAsync();

            return Ok(bank_User_Client_Card_Info);
        }

        private bool Bank_User_Client_Card_InfoExists(string id)
        {
            return _context.Bank_User_Client_Card_Info.Any(e => e.CardNumber == id);
        }
    }
}