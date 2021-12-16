using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Concurrent;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Application.Test
{
    public class XunitTestOutputLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, Microsoft.Extensions.Logging.ILogger> _loggers = new ConcurrentDictionary<string, Microsoft.Extensions.Logging.ILogger>();
        private readonly ITestOutputHelperAccessor _accessor;
        private readonly Func<string, LogLevel, bool> _filter;

        /// <summary>Log minLevel LogLevel.Information</summary>
        public XunitTestOutputLoggerProvider(ITestOutputHelperAccessor accessor)
        {
        }

        public XunitTestOutputLoggerProvider(ITestOutputHelperAccessor accessor, Func<string, LogLevel, bool> filter)
        {
            _accessor = accessor;
            _filter = filter ?? throw new ArgumentNullException(nameof(filter));
        }

        public void Dispose() { }

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            return null;
        }

        private object TestOutput(ITestOutputHelper output, LogEventLevel verbose, object outputTemplate)
        {
            throw new NotImplementedException();
        }

        public static void Register(IServiceProvider provider) =>
            provider.GetRequiredService<ILoggerFactory>().AddProvider(ActivatorUtilities.CreateInstance<XunitTestOutputLoggerProvider>(provider));
    }

}
