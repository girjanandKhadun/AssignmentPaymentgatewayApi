using Newtonsoft.Json;
using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services.PaymentGatewayServices
{
    public class PaymentGatewayAuth
    {
        private readonly UserContext _context;
        private readonly string PaymentGatewayAppid = "0c56f2c2-5457-4a32-ba2b-971afdb9f99e";
        public PaymentGatewayAuth(UserContext context)
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
                var userDetails = _context.User.Where(e => e.AppId == AppId).Select(e => e).FirstOrDefault();
                if(userDetails == null)
                {
                    return false;
                }
                if (userDetails.AppId == PaymentGatewayAppid)
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
