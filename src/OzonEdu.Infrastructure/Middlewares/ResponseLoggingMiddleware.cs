namespace OzonEdu.Infrastructure.Middlewares
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Primitives;

    public class ResponseLoggingMiddleware : LoggingMiddlewareBase
    {
        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
            :base(next, logger)
        {
        }

        public override async Task InvokeAsync(HttpContext context)
        {
            await Next(context);

            await LogResponseAsync(context);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async Task LogResponseAsync(HttpContext context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                // skip GRPC requests
                if (!DoLog(context))
                {
                    return;
                }

                var info = new
                {
                    Path = context.Request.Path.ToString(),
                    context.Response.StatusCode,
                    Headers = context.Response.Headers.Where(_ => !StringValues.IsNullOrEmpty(_.Value))
                        .ToDictionary(x => x.Key, v => v.Value.ToString())
                };

                Logger.LogInformation(Serialize(info));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Failed to log response for {context.Request.Path}");
            }
        }

        protected override bool DoLog(HttpContext context)
        {
            return context.Request.ContentType != "application/grpc";
        }
    }
}
