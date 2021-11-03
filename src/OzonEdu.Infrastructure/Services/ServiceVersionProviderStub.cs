namespace OzonEdu.Infrastructure.Services
{
    using System.Threading.Tasks;
    using OzonEdu.Infrastructure.Contracts;

    public class ServiceVersionProviderStub : IServiceVersionProvider
    {
        private static readonly ServiceVersion serviceVersionStub = new() { Version = "no version", ServiceName = "There is no any instance of service version provider configured for the application" };

        public Task<IServiceVersion> GetServiceVersionInfoAsync()
        {
            return Task.FromResult<IServiceVersion>(serviceVersionStub);
        }

        private class ServiceVersion : IServiceVersion
        {
            public string Version { get; set; }

            public string ServiceName { get; set; }
        }
    }
}
