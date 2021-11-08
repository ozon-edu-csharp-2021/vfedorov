namespace OzonEdu.MerchandiseService.Domain.Models.Base
{
    using System.Collections.Generic;

    public class Name : ValueObject
    {
        public Name(string value)
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
