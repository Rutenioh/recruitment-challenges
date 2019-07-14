using System.Text;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.factories
{
    public class StateNormalizer : INormalizer
    {
        public string Normalize(string state)
        {

            return new StringBuilder(state)
                .Replace("il", "illinois")
                .Replace("ca", "california")
                .Replace("ny", "new york")
                .ToString();
        }
    }
}