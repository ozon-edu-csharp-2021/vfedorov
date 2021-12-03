namespace OzonEdu.MerchandiseService.HttpClient
{
    using System.Threading;
    using System.Threading.Tasks;
    using OzonEdu.MerchandiseService.Models;

    public interface IMerchandiseServiceClient
    {
        /// <summary>
        /// Gets issued merch for the employee
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetIssuedMerchResponse> GetIssuedMerchAsync(long employeeId, CancellationToken cancellationToken);

        /// <summary>
        /// Issues merch for the employee
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task IssueMerchAsync(IssueMerchRequest request, CancellationToken cancellationToken);
    }
}
