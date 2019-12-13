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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Implementations;
using online_shop_backend.Repositories.Interfaces;
using Newtonsoft.Json;

namespace online_shop_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration["ConnectionStrings:OnlineShopDatabase"]));

            services.AddTransient<ICategoriesRepository, EFCategoriesRepository>();
            services.AddTransient<ISubcategoriesRepository, EFSubcategoriesRepository>();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IProducerRepository, EFProducerRepository>();
            services.AddTransient<IProducerDetailRepository, EFProducerDetailRepository>();
            services.AddTransient<IInvoiceRepository, EFInvoiceRepository>();
            services.AddTransient<IInvoiceDetailRepository, EFInvoiceDetailRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<IOrderDetailRepository, EFOrderDetailRepository>();
            services.AddTransient<IPaymentTypeRepository, EFPaymentTypeRepository>();
            services.AddTransient<IPaymentMethodRepository, EFPaymentMethodRepository>();
            services.AddTransient<IDiscountRepository, EFDiscountRepository>();
            services.AddTransient<IReviewRepository, EFReviewRepository>();
            services.AddTransient<IUserDetailRepository, EFUserDetailRepository>();
            services.AddTransient<IShippingMethodRepository, EFShippingMethodRepository>();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}