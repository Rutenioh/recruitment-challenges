namespace Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.frauds
{
    public class EqualsMailFraudRule : IFraudRule
    {
        public bool isFraudulent(Order order, Order suspicious)
        {
            return order.DealId == suspicious.DealId
                   && order.Email == suspicious.Email
                   && order.CreditCard != suspicious.CreditCard;
        }
    }
}