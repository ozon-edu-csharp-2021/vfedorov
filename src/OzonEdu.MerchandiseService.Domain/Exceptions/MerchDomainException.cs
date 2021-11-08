namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    using System;

    public class MerchDomainException : Exception
    {
        public MerchDomainException()
        { }

        public MerchDomainException(string message)
            : base(message)
        { }

        public MerchDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
