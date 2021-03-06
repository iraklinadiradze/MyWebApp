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

using WebAPI.Models;
using WebAPI.Pipelines;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using MediatR;
using System.Reflection;
using System.Resources;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace WebAPIs
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
            var connection = Configuration.GetConnectionString("PilotDB");
            services.AddDbContextPool<PilotDBContext>(options => options.UseSqlServer(connection));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AppLoggingBehaviour<,>));

            services.AddControllers();

            var baseName = "Resources";
            services.AddSingleton(new ResourceManager(baseName, Assembly.GetExecutingAssembly()));

            // Using IStringLocalizer
            services.AddLocalization();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Options=>
             {
                 Options.RequireHttpsMetadata = false;
                 Options.SaveToken = true;
                 Options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidAudience = Configuration["Jwt:Audience"],
                     ValidIssuer = Configuration["Jwt:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                 };
             }
            );

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("fr-FR") };
            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                // For culture-specific formatting of numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // For l10n of UI-related elements, e.g., strings.
                SupportedUICultures = supportedCultures,
            };

            requestLocalizationOptions.DefaultRequestCulture = new RequestCulture("en-US");

            app.UseRequestLocalization(requestLocalizationOptions);

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //            Access - Control - Allow - Headers
            app.UseCors("EnableCORS");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
