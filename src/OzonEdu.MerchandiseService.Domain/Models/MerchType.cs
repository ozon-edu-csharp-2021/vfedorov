namespace OzonEdu.MerchandiseService.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OzonEdu.MerchandiseService.Domain.Exceptions;

    public class MerchType : Enumeration
    {
#pragma warning disable CA2211 // Non-constant fields should not be visible
        public static MerchType WelcomePack = new(10, nameof(WelcomePack));
        public static MerchType ConferenceListenerPack = new(20, nameof(ConferenceListenerPack));
        public static MerchType ConferenceSpeakerPack = new(30, nameof(ConferenceSpeakerPack));
        public static MerchType ProbationPeriodEndingPack = new(40, nameof(ProbationPeriodEndingPack));
        public static MerchType VeteranPack = new(50, nameof(VeteranPack));
#pragma warning restore CA2211 // Non-constant fields should not be visible

        public MerchType(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<MerchType> List() =>
            new[] { WelcomePack, ConferenceListenerPack, ConferenceSpeakerPack, ProbationPeriodEndingPack, VeteranPack };

        public static MerchType FromName(string name)
        {
            var merchType = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (merchType == null)
            {
                throw new MerchDomainException($"Possible values for MerchType: {String.Join(",", List().Select(s => s.Name))}");
            }

            return merchType;
        }

        public static MerchType From(int id)
        {
            var merchType = List().SingleOrDefault(s => s.Id == id);

            if (merchType == null)
            {
                throw new MerchDomainException($"Possible values for MerchType: {String.Join(",", List().Select(s => s.Name))}");
            }

            return merchType;
        }
    }
}
