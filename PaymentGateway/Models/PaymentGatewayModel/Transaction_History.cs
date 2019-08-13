using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class Transaction_History
    {
        [Key]
        public int TransactionId { get; set; }
        public string CardNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string PurchaseDescription { get; set; }
        public string TransactionStatus { get; set; }
        public Transaction_History()
        {

        }
    }
}
