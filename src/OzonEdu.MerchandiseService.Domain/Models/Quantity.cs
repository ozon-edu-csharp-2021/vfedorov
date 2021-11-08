namespace OzonEdu.MerchandiseService.Domain.Models
{
    using System.Collections.Generic;

    public class Quantity : ValueObject
    {
        public Quantity(decimal value)
        {
            this.Value = value;
        }

        public decimal Value { get; init; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
