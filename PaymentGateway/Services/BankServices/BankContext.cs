using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaymentGateway.Models.BankModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services.BankServices
{
    public class BankContext:DbContext
    {
       

        public BankContext(IConfiguration config, DbContextOptions<BankContext> options)
            : base(options)
        {
            
        }
        public DbSet<Bank_User> Bank_User { get; set; }
        public DbSet<Bank_User_Client> Bank_User_Client { get; set; }
        public DbSet<Bank_User_Client_Account> Bank_User_Client_Account { get; set; }
        public DbSet<Bank_User_Client_Card_Info> Bank_User_Client_Card_Info { get; set; }
        public DbSet<Bank_Transaction_History> Bank_Transaction_History { get; set; }
    }
}
