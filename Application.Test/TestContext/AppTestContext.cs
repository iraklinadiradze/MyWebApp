using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Serilog;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform;
using Microsoft.Extensions.Hosting;

namespace Application.Test.TestContext
{
    class AppTestContext : IDisposable
    {

        private static readonly IServiceScopeFactory ScopeFactory;

        public static IConfigurationRoot Configuration { get; }
        static AppTestContext()
        {
            Configuration = new ConfigurationBuilder()
                //                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                //              .AddEnvironmentVariables(Program.ApplicationName + ":")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration).
                CreateLogger();

//            hostBuilder = 
            Host.CreateDefaultBuilder(new string[0])
                  .ConfigureServices((hostContext, services) =>
                  {
                      //                      services.AddHostedService<ConsoleHostedService>();
                  })
                .Build().Run();

            //                RunConsoleAsync();

            //            var host = hostBuilder.Build();

            var startup = new Startup(Configuration);
            var services = new ServiceCollection();

            startup.ConfigureServices(services);
//            services.AddLogging(Log.Logger.);

            //            services.AddSingleton<Serilog.ILogger, Log.Logger>();

            //            var rootContainer = services.BuildServiceProvider();
            //            ScopeFactory = rootContainer.GetService<IServiceScopeFactory>();



        }
        void IDisposable.Dispose()
        {

        }


        public class Startup
        {

            public IConfiguration Configuration { get; }

            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public void ConfigureServices(IServiceCollection services)
            {

            }

        }
    }
}
