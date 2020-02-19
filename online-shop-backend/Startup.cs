using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
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
using online_shop_backend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace online_shop_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string MyCorsPolicy = "MyCorsPolicy";

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
            services.AddTransient<IRefreshTokenRepository, EFRefreshTokenRepository>();

            services.AddTransient<TokenFactory>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(Configuration["SecretKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy(MyCorsPolicy, builder =>
                    {
                        builder.WithOrigins("http://0.0.0.0:8080", "http://localhost:8080");
                    });
            });
            
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

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyCorsPolicy);

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}