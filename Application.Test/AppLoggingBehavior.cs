using MediatR;
//using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace Application.Test.Pipelines
{
    public class AppLoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        private readonly Serilog.ILogger _logger;
        public AppLoggingBehaviour(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            string requestName = typeof(TRequest).Name;
            string unqiueId = Guid.NewGuid().ToString();
            _logger.Information($"Begin Request Id:{unqiueId}, request name:{requestName}");
            var timer = new Stopwatch();
            timer.Start();
            var response = await next();
            timer.Stop();
            _logger.Information($"Begin Request Id:{unqiueId}, request name:{requestName}, total request time:{timer.ElapsedMilliseconds}");
            return response;
        }

    }
}