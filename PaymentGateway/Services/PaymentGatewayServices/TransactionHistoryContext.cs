using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services
{
    public class TransactionHistoryContext : DbContext
    {
        public TransactionHistoryContext(DbContextOptions<TransactionHistoryContext> options) : base(options) { }
        public DbSet<Transaction_History> Transaction_History { get; set; }
    }
}
