using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models.BankModel
{
    public class Bank_User_Client_Account
    {
        [Key]
        public string AccountNumber { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public string AccountType { get; set; }
        public decimal AvailableAmount { get; set; }
        public Bank_User_Client_Account()
        {

        }
    }
}
