namespace OzonEdu.Infrastructure.Middlewares
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Primitives;

    public class RequestLoggingMiddleware : LoggingMiddlewareBase
    {
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
            :base(next, logger)
        {
        }

        public override async Task InvokeAsync(HttpContext context)
        {
            await LogRequestAsync(context);

            await Next(context);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async Task LogRequestAsync(HttpContext context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                if(!DoLog(context))
                {
                    return;
                }

                var info = new
                {
                    Path = context.Request.Path.ToString(),
                    Headers = context.Request.Headers
                        .Where(_ => !StringValues.IsNullOrEmpty(_.Value))
                        .ToDictionary(k => k.Key, v => v.Value.ToString()),
                };

                Logger.LogInformation(Serialize(info));                
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, $"Failed to log request for {context.Request.Path}");
            }
        }
        protected override bool DoLog(HttpContext context)
        {
            return context.Request.ContentType != "application/grpc";
        }
    }
}
