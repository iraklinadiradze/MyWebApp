using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using Application.Common.Interfaces;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Xunit.Abstractions;
using Serilog;
using Serilog.Events;
using Xunit;

namespace Application.Test.Domains.Procurment.Purchase
{
    public class PurchaseTestAutoFac
	{
		ILogger _logger;
		public PurchaseTestAutoFac(ILogger logger)
		{
			_logger = logger;
		}

		[Fact]
		public void FactTest()
		{
			_logger.Information("rrrr");
			_logger.Warning("xxxxxxxxxxxxxxxxx");

			Assert.Equal(6, 6);
		}
	}
	/*
	public class CustomLoggerHelper
    {
		public ITestOutputHelper OutputHelper { get; }

		public CustomLoggerHelper(ITestOutputHelper outputHelper)
		{
			OutputHelper = outputHelper;
		}

		public ILogger GetLogger()
        {
			return new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.TestOutput(OutputHelper, Serilog.Events.LogEventLevel.Verbose)
				.CreateLogger();

			CustomLogger abc;

		}

	}

	
	public class CustomLogger:Serilog.Log
	{
		public ITestOutputHelper OutputHelper { get; }
		Serilog.ILogger _Logger;

		public CustomLogger(ITestOutputHelper outputHelper)
		{
			OutputHelper = outputHelper;

			_Logger = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.TestOutput(OutputHelper, Serilog.Events.LogEventLevel.Verbose)
				.CreateLogger();

		}

		public void Write(LogEvent logEvent)
        {
			_Logger.

		}
    }

*/

	public class ServiceRegistration : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			/*
			builder.Register(context => new MyService())
				.As<IMyService>()
				.InstancePerLifetimeScope();
			*/

			var _builder = new DbContextOptionsBuilder<CoreDBContext>();
			_builder.UseInMemoryDatabase(databaseName: "LibraryDbInMemory");
			var _dbContext = new CoreDBContext(_builder.Options);
			_dbContext.Database.EnsureDeleted();
			_dbContext.Database.EnsureCreated();


			builder.Register(context => _dbContext ) 
				.As<ICoreDBContext>()
				.InstancePerLifetimeScope();

			builder.RegisterType<Mediator>()
				.As<IMediator>()
				.InstancePerLifetimeScope();

            /*
						builder.RegisterType<CustomLogger>()
							.As<ILogger>()
							.InstancePerLifetimeScope();
			*/
            Xunit.Sdk.TestOutputHelper _testOtputHelper = new Xunit.Sdk.TestOutputHelper();

			var _Logger = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.TestOutput(_testOtputHelper, Serilog.Events.LogEventLevel.Verbose)
				.CreateLogger();

			builder.Register(context => _Logger)
				.As<ILogger>()
				.InstancePerLifetimeScope();

		}
	}

}
