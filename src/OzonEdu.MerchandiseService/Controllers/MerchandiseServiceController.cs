namespace OzonEdu.MerchandiseService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using OzonEdu.MerchandiseService.Models;

    [Route("api/v1/merch")]
    [ApiController]
    public class MerchandiseServiceController : ControllerBase
    {
        [HttpGet("issuedfor/{employeeId:long}")]
        public async Task<ActionResult<GetIssuedMerchResponse>> GetIssuedMerch(long employeeId, CancellationToken cancellationToken)
        {
            var result = new GetIssuedMerchResponse
            {
                EmployeeId = employeeId,
                IssuedMerch = new List<IssuedMerchInfo>
                {
                    new IssuedMerchInfo {MerchType = MerchType.VeteranPack, IssueDate = DateTime.UtcNow },
                    new IssuedMerchInfo {MerchType = MerchType.ConferenceListenerPack, IssueDate = DateTime.UtcNow },
                }
            };

            return await Task.FromResult(result); 
        }

        [HttpPost]
        public async Task<ActionResult> IssueMerch(IssueMerchRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Ok());
        }
    }
}
