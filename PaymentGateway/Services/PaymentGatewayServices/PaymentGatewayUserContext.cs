using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaymentGateway.Models.PaymentGatewayModel;
using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services.PaymentGatewayServices
{
    public class PaymentGatewayUserContext:DbContext
    {
        public PaymentGatewayUserContext(DbContextOptions<PaymentGatewayUserContext> options)
            : base(options) {  }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Client> User_Clients { get; set; }
        public DbSet<User_Client_Card_Info> User_Clients_Card_Info { get; set; }
        public DbSet<Transaction_History> Transaction_History { get; set; }

    }
}
