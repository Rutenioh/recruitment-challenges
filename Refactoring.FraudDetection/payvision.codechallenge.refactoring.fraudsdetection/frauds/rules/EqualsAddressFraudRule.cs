namespace Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.frauds
{
    public class EqualsAddressFraudRule : IFraudRule
    {
        public bool isFraudulent(Order order, Order suspicious)
        {
            return order.DealId == suspicious.DealId
                        && order.State == suspicious.State
                        && order.ZipCode == suspicious.ZipCode
                        && order.Street == suspicious.Street
                        && order.City == suspicious.City
                        && order.CreditCard != suspicious.CreditCard;
        }
    }
}