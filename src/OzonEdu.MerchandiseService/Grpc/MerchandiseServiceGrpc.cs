namespace OzonEdu.MerchandiseService.Grpc
{
    using System;
    using System.Threading.Tasks;
    using global::Grpc.Core;
    using Google.Protobuf.WellKnownTypes;

    public class MerchandiseService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase   
    {
        public override Task<GetIssuedMerchResponse> GetIssuedMerch(GetIssuedMerchRequest request, ServerCallContext context)
        {
            var result = new GetIssuedMerchResponse
            {
                Merch =
                {
                    new IssuedMerch{ MerchType = MerchType.VeteranPack, IssueDate = Timestamp.FromDateTime(DateTime.UtcNow)},
                    new IssuedMerch{ MerchType = MerchType.ProbationPeriodEndingPack, IssueDate = Timestamp.FromDateTime(DateTime.UtcNow)}
                }
            };

            return Task.FromResult(result);     
            
        }

        public override Task<Empty> IssueMerch(IssueMerchRequest request, ServerCallContext context)
        {
            //return base.IssueMerch(request, context);

            return Task.FromResult(new Empty());
        }
    }
}
