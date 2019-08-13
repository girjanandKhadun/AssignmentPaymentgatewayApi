using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models.BankModel;

namespace PaymentGateway.Services.BankServices
{
    public class BankTransactionHistoryContext: DbContext
    {
        public BankTransactionHistoryContext(DbContextOptions<BankTransactionHistoryContext> options) : base(options) { }
        public DbSet<Bank_Transaction_History> Bank_Transaction_History { get; set; }
    }
}
