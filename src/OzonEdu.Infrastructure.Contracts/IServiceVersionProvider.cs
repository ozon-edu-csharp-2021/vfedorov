namespace OzonEdu.Infrastructure.Contracts
{
    using System;
    using System.Threading.Tasks;

    public interface IServiceVersionProvider
    {
        Task<IServiceVersion> GetServiceVersionInfoAsync();
    }
}
