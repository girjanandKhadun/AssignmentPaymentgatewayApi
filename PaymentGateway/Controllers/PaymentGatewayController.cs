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

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentGatewayController : ControllerBase
    {
        private readonly PaymentGatewayUserContext _context;

        public PaymentGatewayController(PaymentGatewayUserContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> PostPaymentGateway(string appid, [FromBody] User_Client_Card_Info user_Client_Card_Info, [FromServices]
        BankContext BankDb)
        {
            var TransactionHist = new Models.Transaction_History();
            try
            {
                //Authentication of API
                if (appid == null)
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
                if (_context.User_Clients_Card_Info.Where(e => e.CardNumber == user_Client_Card_Info.CardNumber) == null)
                {
                    return BadRequest("Card Number is not valid");
                }
                //linked the card with his account
                var bank_User_Client_Card_Info = BankDb.Bank_User_Client_Card_Info.Where(e => e.CardNumber == user_Client_Card_Info.CardNumber).Select(e => e).FirstOrDefault();
                if (bank_User_Client_Card_Info == null)
                {
                    return BadRequest("Card Number is not valid");
                }
                //declare new amount
                decimal availableAmount = 0;
                var account = BankDb.Bank_User_Client_Account.Where(e => e.AccountNumber == bank_User_Client_Card_Info.AccountNumber).FirstOrDefault();
                if (account == null)
                {
                    return BadRequest("Account Number is not valid");
                }
                //Deduce the purchase price in the account
                availableAmount = account.AvailableAmount - user_Client_Card_Info.TransactionAmount;
                //update the db available amount
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
                //write transaction into hist
                BankDb.Bank_Transaction_History.Add(new Models.BankModel.Bank_Transaction_History
                {
                    TransactionId = Guid.NewGuid().ToString(),
                    CardNumber = user_Client_Card_Info.CardNumber,
                    TransactionDate = DateTime.Now,
                    TransactionAmount = user_Client_Card_Info.TransactionAmount,
                    TransactionType = "Debit",
                    TransactionStatus = "Success"
                });
                try
                {
                    await BankDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

               TransactionHist = new Models.Transaction_History
                {
                    TransactionDate = DateTime.Now,
                    CardNumber = user_Client_Card_Info.CardNumber,
                    PurchaseAmount = user_Client_Card_Info.TransactionAmount,
                    PurchaseDescription = user_Client_Card_Info.PurchaseDescription,
                    TransactionStatus = "Success"
                };
                _context.Transaction_History.Add(TransactionHist);
                try
                {
                    await _context.SaveChangesAsync();
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
            return Ok(TransactionHist);
        }

        [HttpGet]
        public IActionResult GetPaymentGateway(string Appid, string CardNumber)
        {
            //Authentication of API
            if (Appid == null)
            {
                return BadRequest();
            }
            var user = _context.Users.Where(e => e.AppId.ToString().CompareTo(Appid) == 1).Select(e => e);
            if (user == null)
            {
                return BadRequest("You are not authorised to use the API, Please register or Contact Administrator");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction_History = _context.Transaction_History.Where(e=> e.CardNumber == CardNumber).Select(e =>e).ToList();

            if (transaction_History == null)
            {
                return NotFound();
            }

            return Ok(transaction_History);
        }

    }
}
