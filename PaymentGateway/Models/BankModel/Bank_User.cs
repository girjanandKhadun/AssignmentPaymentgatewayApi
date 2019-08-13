using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models.BankModel
{
    public class Bank_User
    {
        [Key]
        public int userId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Appid { get; set; }

        public Bank_User()
        {

        }
    }
}
