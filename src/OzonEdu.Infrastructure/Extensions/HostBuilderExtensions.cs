namespace OzonEdu.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using OzonEdu.Infrastructure.StartupFilters;
    using OzonEdu.Extensions;
    using System.Collections.Generic;
    using OzonEdu.Infrastructure.Interceptors;
    using OzonEdu.Infrastructure.Filters;
    using OzonEdu.Infrastructure.Swagger;

    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Adds reusable infrastructure middlewares
        /// </summary>
        /// <param name="builder">the <see cref="IHostBuilder"/> instance</param>
        /// <returns>Configured <see cref="IHostBuilder"/></returns>
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ThrowIfNull(nameof(builder));

            builder.ConfigureServices(services =>
            {
                // set up service middlewares (version, healthcheck)
                services.AddSingleton<IStartupFilter, ServiceStartupFilter>();

                // set up logging middlewares
                services.AddSingleton<IStartupFilter, LoggingStartupFilter>();

                // set up Swagger
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                services.AddSwaggerGen(options =>
                {
                    // TODO document should be passed outside of the method 
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "OzonEdu.MerchandiseService", Version = "v1" });

                    options.CustomSchemaIds(x => x.FullName);

                    options.OperationFilter<HeaderOperationFilter>();
                });

                services.AddGrpc(options =>
                    options.Interceptors.Add<LoggingInterceptor>()
                );
            });

            return builder;
        }

        /// <summary>
        /// Configures HTTP services
        /// </summary>
        /// <param name="builder">The <see cref="IHostBuilder"/> instance</param>
        /// <returns></returns>
        public static IHostBuilder AddHttp(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddControllers(options =>
                    options.Filters.Add<GlobalExceptionFilter>()
                );
            });

            return builder;
        }
    }
}
