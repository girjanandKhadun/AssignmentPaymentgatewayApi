using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models.BankModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services.BankServices
{
    public class BankUserClientCardInfoContext:DbContext
    {
        public BankUserClientCardInfoContext(DbContextOptions<BankUserClientCardInfoContext> options) : base(options) { }
        public DbSet<Bank_User_Client_Card_Info> Bank_User_Client_Card_Info { get; set; }
    }
}
