namespace OzonEdu.MerchandiseService.Services
{
    using System.Reflection;
    using System.Threading.Tasks;
    using OzonEdu.Infrastructure.Contracts;
    using OzonEdu.MerchandiseService.Models;

    /// <summary>
    /// Provides implementation of <see cref="IServiceVersionProvider"/> service
    /// </summary>
    public class ServiceVersionProviderService : IServiceVersionProvider
    {
        private readonly IServiceVersion serviceVersion;

        public ServiceVersionProviderService()
        {
            AssemblyName assemblyName = typeof(ServiceVersionProviderService).Assembly.GetName();

            serviceVersion = new ServiceVersionInfo
            {
                Version = assemblyName.Version?.ToString() ?? "no version",
                ServiceName = assemblyName.Name
            };
        }

        public async Task<IServiceVersion> GetServiceVersionInfoAsync()
        {
            return await Task.FromResult(serviceVersion);
        }
    }
}
