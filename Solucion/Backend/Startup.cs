using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapper;
using Backend.Helpers;
using Backend.Models;
using Backend.Services;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Common;
using Logging;
using Application.Interface;
using Application.Main;
using Domain.Core;
using Domain.Interface;
using Infraestructure.Interface;
using Infraestructure.Repository;
using System.Text;

namespace Backend
{
    public class Startup
    {
        readonly string myPolicy = "policyApiBgr";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingsProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            var corsAllowSpecific = Configuration["Config:OriginCors"].Split(';');

            services.AddCors(options => options.AddPolicy(name: myPolicy, builder => builder.WithOrigins(corsAllowSpecific)
                                                                                       .AllowAnyHeader()
                                                                                       .AllowCredentials()
                                                                                       .AllowAnyMethod()));

            services.AddMvc();
            services.AddControllersWithViews().
             AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
             });

            var appSettingsSection = Configuration.GetSection("Config");

            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            services.Configure<JwtSettings>(Configuration.GetSection(nameof(JwtSettings)));
            services.AddTransient<IJwtService, JwtService>();

            services.AddDbContext<NttDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Nttdata")));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IDbContext>(provider => provider.GetService<NttDataContext>());

            /*registro application*/
            services.AddScoped<IClientApplication, ClientApplication>();
            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IPersonApplication, PersonApplication>();
            services.AddScoped<ITransactionApplication, TransactionApplication>();

            /*registro domain*/
            services.AddScoped<IClientDomain, ClientDomain>();
            services.AddScoped<IAccountDomain, AccountDomain>();
            services.AddScoped<IPersonDomain, PersonDomain>();
            services.AddScoped<ITransactionDomain, TransactionDomain>();

            /*registro repository*/
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var Issuer = appSettings.Issuer;
            var Audience = appSettings.Audience;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();
            app.UseCors(myPolicy);
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My backend NttData v1");
                c.RoutePrefix = string.Empty;
            });

            //app.UseMvc();
        }
    }
}
