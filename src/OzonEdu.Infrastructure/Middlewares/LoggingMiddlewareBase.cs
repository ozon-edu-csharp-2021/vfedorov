namespace OzonEdu.Infrastructure.Middlewares
{
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public abstract class LoggingMiddlewareBase
    {
        private readonly JsonSerializerOptions serializerOptions = new() { WriteIndented = true };

        public LoggingMiddlewareBase(RequestDelegate next, ILogger logger)
        {
            this.Next = next;
            this.Logger = logger;
        }

        /// <summary>
        /// Gets next middleware delegate
        /// </summary>
        protected RequestDelegate Next { get; }

        /// <summary>
        /// Gets logger instance
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// Executes middleware code
        /// </summary>
        /// <param name="context">Passed context</param>
        /// <returns></returns>
        public abstract Task InvokeAsync(HttpContext context);

        protected virtual string Serialize<T>(T data)
        {
            return JsonSerializer.Serialize(data, serializerOptions);
        }

        protected virtual bool DoLog(HttpContext context)
        {
            return false;
        }

    }
}
