using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models.PaymentGatewayModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services.PaymentGatewayServices
{
    public class UserClientCardInfoContext:DbContext
    {
        public UserClientCardInfoContext(DbContextOptions<UserClientCardInfoContext> options) : base(options) { }
        public DbSet<User_Client_Card_Info> User_Client_Card_Info { get; set; }
    }
}
