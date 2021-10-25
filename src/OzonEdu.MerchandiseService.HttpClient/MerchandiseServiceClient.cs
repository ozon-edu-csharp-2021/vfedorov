namespace OzonEdu.MerchandiseService.HttpClient
{
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using OzonEdu.MerchandiseService.Models;

    public class MerchandiseServiceClient
    {
        private readonly HttpClient httpClient;

        private readonly JsonSerializerOptions jsonOptions = new();
        public MerchandiseServiceClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            jsonOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        }

        public async Task<GetIssuedMerchResponse> GetIssuedMerchAsync(long employeeId, CancellationToken cancellationToken)
        {
            using var response = await httpClient.GetAsync($"api/v1/merch/issuedfor/{employeeId}", cancellationToken);

            var body = await response.Content.ReadAsStringAsync(cancellationToken);

            return JsonSerializer.Deserialize<GetIssuedMerchResponse>(body, jsonOptions);
        }

        public async Task IssueMerchAsync(IssueMerchRequest request, CancellationToken cancellationToken)
        {
            var serializedData = JsonSerializer.Serialize(request);

            using var content = new StringContent(serializedData, Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync("api/v1/merch", content, cancellationToken);

            // TODO decide what to do with response
        }
    }
}
