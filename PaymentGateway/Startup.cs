using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaymentGateway.Services;
using PaymentGateway.Services.BankServices;
using PaymentGateway.Services.PaymentGatewayServices;

namespace PaymentGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string PaymentGatewayConnectionString = Configuration.GetConnectionString("PaymentGatewayConn");
            string BankConnectionString = Configuration.GetConnectionString("BankConn");

            //services.AddDbContext<TransactionHistoryContext>(options => options.UseMySql(PaymentGatewayConnectionString));
            //services.AddDbContext<UserContext>(options => options.UseMySql(PaymentGatewayConnectionString));
            //services.AddDbContext<UserClientContext>(options => options.UseMySql(PaymentGatewayConnectionString));
            //services.AddDbContext<UserClientCardInfoContext>(options => options.UseMySql(PaymentGatewayConnectionString));

            services.AddDbContext<PaymentGatewayUserContext>(options => options.UseMySql(PaymentGatewayConnectionString));
            
            services.AddDbContext<BankContext>(options => options.UseMySql(BankConnectionString));

            //services.AddDbContext<BankTransactionHistoryContext>(options => options.UseMySql(BankConnectionString));
            //services.AddDbContext<BankUserContext>(options => options.UseMySql(BankConnectionString));
            //services.AddDbContext<BankUserClientContext>(options => options.UseMySql(BankConnectionString));
            //services.AddDbContext<BankUserClientAccountContext>(options => options.UseMySql(BankConnectionString));
            //services.AddDbContext<BankUserClientCardInfoContext>(options => options.UseMySql(BankConnectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
