namespace OzonEdu.Infrastructure.StartupFilters
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using OzonEdu.Infrastructure.Extensions;

    public class LoggingStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseLoggingMiddleware();
                next(app);
            };
        }
    }
}
