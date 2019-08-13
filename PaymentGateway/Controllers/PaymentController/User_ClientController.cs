using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models.PaymentGatewayModel;
using PaymentGateway.Services.PaymentGatewayServices;

namespace PaymentGateway.Controllers.PaymentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_ClientController : ControllerBase
    {
        private readonly UserClientContext _context;
        public User_ClientController(UserClientContext context)
        {
            _context = context;            
        }

        // GET: api/User_Client
        [HttpGet]
        public IEnumerable<User_Client> GetUser_Client()
        {
            return _context.User_Client;
        }

        // GET: api/User_Client/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser_Client([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user_Client = await _context.User_Client.FindAsync(id);

            if (user_Client == null)
            {
                return NotFound();
            }

            return Ok(user_Client);
        }

        // PUT: api/User_Client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_Client([FromRoute] string id, [FromBody] User_Client user_Client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_Client.IdentityNumber)
            {
                return BadRequest();
            }

            _context.Entry(user_Client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_ClientExists(id))
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

        // POST: api/User_Client
        [HttpPost]
        public async Task<IActionResult> PostUser_Client([FromBody] User_Client user_Client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.User_Client.Add(user_Client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_Client", new { id = user_Client.IdentityNumber }, user_Client);
        }

        // DELETE: api/User_Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_Client([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user_Client = await _context.User_Client.FindAsync(id);
            if (user_Client == null)
            {
                return NotFound();
            }

            _context.User_Client.Remove(user_Client);
            await _context.SaveChangesAsync();

            return Ok(user_Client);
        }

        private bool User_ClientExists(string id)
        {
            return _context.User_Client.Any(e => e.IdentityNumber == id);
        }
    }
}