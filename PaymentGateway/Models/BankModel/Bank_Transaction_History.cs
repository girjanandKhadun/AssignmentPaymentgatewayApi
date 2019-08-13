using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models.BankModel
{
    public class Bank_Transaction_History
    {
        [Key]
        public string TransactionId { get; set; }
        public string CardNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionStatus { get; set; }
        public Bank_Transaction_History()
        {

        }
    }
}
