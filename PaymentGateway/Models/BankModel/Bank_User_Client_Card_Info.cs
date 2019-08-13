using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models.BankModel
{
    public class Bank_User_Client_Card_Info
    {
        [Key]
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; }
        public string CardType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Bank_User_Client_Card_Info()
        {

        }
    }
}
