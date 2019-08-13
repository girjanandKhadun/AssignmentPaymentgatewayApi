using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models.PaymentGatewayModel
{
    public class User_Client_Card_Info
    {
        [Key]
        public string CardNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string CardType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string PurchaseDescription { get; set; }
        public User_Client_Card_Info()
        {

        }
    }
}
