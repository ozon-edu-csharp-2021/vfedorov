namespace OzonEdu.MerchandiseService.Models
{
    using System.Collections.Generic;

    public class GetIssuedMerchResponse
    {
        public long EmployeeId { get; set; }
        public List<IssuedMerchInfo> IssuedMerch { get; set; }
    }
}
