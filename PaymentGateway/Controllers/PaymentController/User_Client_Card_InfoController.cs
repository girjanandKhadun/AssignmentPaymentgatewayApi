using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models.PaymentGatewayModel;
using PaymentGateway.Services.BankServices;
using PaymentGateway.Services.PaymentGatewayServices;

namespace PaymentGateway.Controllers.PaymentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_Client_Card_InfoController : ControllerBase
    {
        private readonly PaymentGatewayUserContext _context;

        public User_Client_Card_InfoController(PaymentGatewayUserContext context)
        {
            _context = context;
        }

        // PUT: api/User_Client_Card_Info
        [HttpPost]
        public async Task<IActionResult> PostUser_Client_Card_Info(string appid, [FromBody] User_Client_Card_Info user_Client_Card_Info, [FromServices]
        BankContext BankDb)
        {
            try
            {
                //Authentication of API
                if(appid == null)
                {
                    return BadRequest();
                }
                var user = _context.Users.Where(e => e.AppId.ToString().CompareTo(appid) == 1).Select(e => e);
                if (user == null)
                {
                    return BadRequest("You are not authorised to use the API, Please register or Contact Administrator");
                }
                // Verify Model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //Check if user has valid card details
                if(_context.User_Clients_Card_Info.Where(e => e.CardNumber == user_Client_Card_Info.CardNumber) == null)
                {
                    return BadRequest("Card Number is not valid");
                }

                var bank_User_Client_Card_Info = BankDb.Bank_User_Client_Card_Info.Where(e => e.CardNumber == user_Client_Card_Info.CardNumber).Select(e => e).FirstOrDefault();
                if (bank_User_Client_Card_Info == null)
                {
                    return BadRequest("Card Number is not valid");
                }
                decimal availableAmount = 0;
                var account = BankDb.Bank_User_Client_Account.Where(e => e.AccountNumber == bank_User_Client_Card_Info.AccountNumber).FirstOrDefault();
                if (account == null)
                {
                    return BadRequest("Account Number is not valid");
                }
                availableAmount = account.AvailableAmount - user_Client_Card_Info.TransactionAmount;

                account.AvailableAmount = availableAmount;
                BankDb.Entry(account).State = EntityState.Modified;

                try
                {
                    await BankDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction("GetUser_Client_Card_Info", new { id = user_Client_Card_Info.CardNumber }, user_Client_Card_Info);
        }
    }
}