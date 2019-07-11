using System.Collections.Generic;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.frauds
{
    public class DefaultFraudChecker : IFraudChecker
    {

        List<IFraudRule> fraudRules = new List<IFraudRule>();

        public DefaultFraudChecker()
        {
            fraudRules.Add(new EqualsMailFraudRule());
            fraudRules.Add(new EqualsAddressFraudRule());
        }

        public List<FraudResult> check(List<Order> orders)
        {
            List<FraudResult> fraudResults = new List<FraudResult>();

            for (int i = 0; i < orders.Count; i++)
            {
                var current = orders[i];

                for (int j = i + 1; j < orders.Count; j++)
                {
                    var suspiciousOrder = orders[j];

                    if (IsFraudulent(current, suspiciousOrder)) { 
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = suspiciousOrder.OrderId });
                    }
                }
            }

            return fraudResults;
        }

        /**
         * Check the rules if an order is fraudulent. With only one true rule the order is fraudulent
         */
        private bool IsFraudulent(Order current, Order suspiciousOrder)
        {
            foreach (var fraudRule in fraudRules)
            {
                if(fraudRule.isFraudulent(current, suspiciousOrder))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
