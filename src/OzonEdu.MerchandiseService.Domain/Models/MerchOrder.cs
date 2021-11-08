namespace OzonEdu.MerchandiseService.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MerchOrder : Entity<long>
    {
        private int orderStatus;
        private int merchType;
        private List<int> merchItems;
    }
}
