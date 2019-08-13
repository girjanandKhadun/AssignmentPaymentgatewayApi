using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models.BankModel;

namespace PaymentGateway.Services.BankServices
{
    public class BankUserClientContext: DbContext
    {
        public BankUserClientContext(DbContextOptions<BankUserClientContext> options) : base(options) { }
        public DbSet<Bank_User_Client> Bank_User_Client { get; set; }
    }
}
