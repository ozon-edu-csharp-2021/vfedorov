namespace OzonEdu.Infrastructure.Middlewares
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;

    public class ServiceHealthMiddleware
    {
        private readonly RequestDelegate next;
        public ServiceHealthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task InvokeAsync(HttpContext context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
        }

    }

    public static class ServiceHealthMiddlewareExtensions
    {
        public static IApplicationBuilder UseServiceHealthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ServiceHealthMiddleware>();
        }
    }
}
