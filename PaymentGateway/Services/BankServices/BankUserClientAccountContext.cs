using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models.BankModel;

namespace PaymentGateway.Services.BankServices
{
    public class BankUserClientAccountContext: DbContext
    {
        public BankUserClientAccountContext(DbContextOptions<BankUserClientAccountContext> options) : base(options) { }
        public DbSet<Bank_User_Client_Account> Bank_User_Client_Account { get; set; }
    }
}
