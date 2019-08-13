using PaymentGateway.Models.BankModel;
using PaymentGateway.Services.BankServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services.PaymentGatewayServices
{
    public class BankAuth
    {
        private readonly BankUserContext _context;
        private readonly string BankAppid = "593805db-4f40-4f0a-b1c7-93610989d9a9";
        public BankAuth(BankUserContext context)
        {
            _context = context;
        }

        public bool AuthenticateUser(string AppId)
        {
            try
            {
                if (AppId == null)
                {
                    return false;
                }
                var userDetails = _context.Bank_User.Where(e => e.Appid == AppId).Select(e => e).FirstOrDefault();

                if (userDetails == null)
                {
                    return false;
                }
                if (userDetails.Appid == BankAppid)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
