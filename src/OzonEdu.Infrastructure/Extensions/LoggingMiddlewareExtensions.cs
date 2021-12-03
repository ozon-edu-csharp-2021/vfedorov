namespace OzonEdu.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using OzonEdu.Infrastructure.Middlewares;

    public static class LoggingMiddlewareExtensions
    {
        /// <summary>
        /// Adds request and response logging middleware
        /// </summary>
        /// <param name="builder">the <see cref="IApplicationBuilder"/> instance to configure</param>
        /// <returns>the configured <see cref="IApplicationBuilder"/> instance</returns>
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder
                .UseMiddleware<RequestLoggingMiddleware>()
                .UseMiddleware<ResponseLoggingMiddleware>();
        }
    }
}
