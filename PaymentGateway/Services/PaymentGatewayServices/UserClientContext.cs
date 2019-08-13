using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models.PaymentGatewayModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services.PaymentGatewayServices
{
    public class UserClientContext:DbContext
    {
        public UserClientContext(DbContextOptions<UserClientContext> options) : base(options) { }
        public DbSet<User_Client> User_Client { get; set; }
    }
}
