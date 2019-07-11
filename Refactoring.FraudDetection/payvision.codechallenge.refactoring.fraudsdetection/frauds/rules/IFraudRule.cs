namespace Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.frauds
{
    public interface IFraudRule
    {
        bool isFraudulent(Order order, Order suspicious);
    }
}