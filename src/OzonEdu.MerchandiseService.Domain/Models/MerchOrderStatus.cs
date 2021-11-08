namespace OzonEdu.MerchandiseService.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MerchOrderStatus : Enumeration
    {

        public MerchOrderStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
