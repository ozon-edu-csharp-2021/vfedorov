namespace OzonEdu.MerchandiseService.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FullName : ValueObject
    {
        public FullName(string value)
        {
            this.Value = value;
        }

        public string Value { get; init; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}
