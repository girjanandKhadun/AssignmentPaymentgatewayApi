using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models.BankModel;


namespace PaymentGateway.Services.BankServices
{
    public class BankUserContext: DbContext
    {
        public BankUserContext(DbContextOptions<BankUserContext> options) : base(options) { }
        public DbSet<Bank_User> Bank_User { get; set; }
    }
}
