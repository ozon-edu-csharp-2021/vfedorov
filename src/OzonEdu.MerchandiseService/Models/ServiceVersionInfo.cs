namespace OzonEdu.MerchandiseService.Models
{
    using OzonEdu.Infrastructure.Contracts;

    public class ServiceVersionInfo : IServiceVersion
    {
        public string Version { get; init; }

        public string ServiceName { get; init; }

        public override string ToString()
        {
            return $"version: {Version}, serviceName: {ServiceName}";
        }
    }
}
