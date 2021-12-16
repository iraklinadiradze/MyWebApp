using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Application.Common.Interfaces;
using Application.Test.Pipelines;
using DataAccessLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Xunit.Abstractions;
using Xunit.DependencyInjection;


namespace Application.Test
{
    class Startup
    {

        ITestOutputHelper _testOutputHelper;
        IServiceCollection _services;

        public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor)
        {
            _testOutputHelper = accessor.Output;
        }

        public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
        {

            var outtemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] [{SourceContext}] {NewLine}{Message}{NewLine}{Exception}";

           Serilog.ILogger _Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File("C:\\Apps\\MyWebApp\\Application.Test\\Log.txt", outputTemplate: outtemplate )
//                .WriteTo.TestOutput(new tes)
                .CreateLogger();

            services.AddSingleton<Serilog.ILogger>(_Logger);

            services.AddMediatR(Assembly.Load("Application").GetTypes().Union(Assembly.Load("DataAccessLayer").GetTypes()).ToArray());
            services.AddDbContext<CoreDBContext>(options => options.UseInMemoryDatabase(databaseName: "LibraryDbInMemory111"));

            services.AddSingleton<ICoreDBContext, CoreDBContext>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AppLoggingBehaviour<,>));

//            AppLoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>


            _services = services;
        }


    }
}
