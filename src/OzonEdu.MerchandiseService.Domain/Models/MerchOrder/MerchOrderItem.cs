namespace OzonEdu.MerchandiseService.Domain.Models.MerchOrder
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MerchOrderItem : Entity<long>
    {
        public string Sku { get; private set; }
        public Item Item { get; private set; }
    }
}
