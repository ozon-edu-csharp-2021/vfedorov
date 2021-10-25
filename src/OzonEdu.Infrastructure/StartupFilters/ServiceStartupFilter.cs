namespace OzonEdu.Infrastructure.StartupFilters
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using OzonEdu.Infrastructure.Middlewares;

    public class ServiceStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/version", _ => _.UseServiceVersionMiddleware())
                   .Map("/ready", _ => _.UseServiceHealthMiddleware())
                   .Map("/live", _ => _.UseServiceHealthMiddleware());

                next(app);
            };
        }
    }
}
