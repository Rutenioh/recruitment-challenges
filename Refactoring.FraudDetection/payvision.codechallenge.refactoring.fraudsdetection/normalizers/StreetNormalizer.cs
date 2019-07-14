using System.Text;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.factories
{
    public class StreetNormalizer : INormalizer
    {
        public string Normalize(string street)
        {
            return new StringBuilder(street)
                .Replace("st.", "street")
                .Replace("rd.", "road")
                .ToString();
        }
    }
}