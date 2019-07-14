using System;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.factories
{
    public class OrderNormalizerFactory : INormalizerFactory
    {
        public const string MAIL = "MAIL";
        public const string STATE = "STATE";
        public const string STREET = "STREET";

        public INormalizer Create(string type)
        {
            INormalizer normalizer;
            if (type.Equals(MAIL))
            {
                normalizer = new MailNormalizer();
            }
            else if (type.Equals(STATE))
            {
                normalizer = new StateNormalizer();
            }
            else if (type.Equals(STREET))
            {
                normalizer = new StreetNormalizer();
            }
            else
            {
                throw new ArgumentException("Normalizer Type not valid");
            }
            return normalizer;
        }

    }
}
