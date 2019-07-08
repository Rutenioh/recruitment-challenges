// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class OrderNormalizer : INormalizer
    {
        List<IRule> normalizerRules = new List<IRule>();

        public OrderNormalizer()
        {
            normalizerRules.Add(new MailNormalizerRule());
            normalizerRules.Add(new StreetNormalizerRule());
            normalizerRules.Add(new StateNormalizerRule());
        }
        public void Normalize(Order order)
        {
            foreach (var rule in normalizerRules)
            {
                rule.Normalize(order);
            }
        }
    }
}