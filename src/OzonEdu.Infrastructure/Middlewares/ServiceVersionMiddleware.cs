namespace OzonEdu.Infrastructure.Middlewares
{
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using OzonEdu.Infrastructure.Contracts;
    using OzonEdu.Infrastructure.Services;

    public class ServiceVersionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IServiceVersionProvider serviceVersionProvider;
        private readonly JsonSerializerOptions serializerOptions;

        public ServiceVersionMiddleware(RequestDelegate next, IServiceVersionProvider serviceVersionProvider = null)
        {
            this.next = next;
            this.serviceVersionProvider = serviceVersionProvider ?? new ServiceVersionProviderStub();
            this.serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task InvokeAsync(HttpContext context)
        {
            IServiceVersion info = await serviceVersionProvider.GetServiceVersionInfoAsync();
            await context.Response.WriteAsJsonAsync(info, serializerOptions);
        }

    }

    public static class ServiceVersionMiddlewareExtensions
    {
        public static IApplicationBuilder UseServiceVersionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ServiceVersionMiddleware>();
        }
    }
}
