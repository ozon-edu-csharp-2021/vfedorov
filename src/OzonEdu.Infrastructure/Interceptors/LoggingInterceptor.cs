namespace OzonEdu.Infrastructure.Interceptors
{
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Grpc.Core;
    using Grpc.Core.Interceptors;
    using Microsoft.Extensions.Logging;

    public class LoggingInterceptor : Interceptor
    {
        private readonly ILogger<LoggingInterceptor> logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            this.logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            LogData(request);

            var response = await base.UnaryServerHandler(request, context, continuation);

            LogData(response);

            return response;
        }

        private void LogData<TData>(TData response, string errorText = null)
        {
            try
            {
                var responseSerialized = JsonSerializer.Serialize(response);
                logger.LogInformation(responseSerialized);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, errorText ?? "Failed to log GRPC request/response");
            }
        }
    }
}
