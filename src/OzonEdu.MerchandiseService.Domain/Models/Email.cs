namespace OzonEdu.MerchandiseService.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Email : ValueObject
    {
        public Email(string value)
        {
            Value = value;
        }

        public string Value { get; init; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
