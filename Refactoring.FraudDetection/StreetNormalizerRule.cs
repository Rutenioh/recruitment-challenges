// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class StreetNormalizerRule : IRule
    {

        public void Normalize(Order order)
        {
            //Normalize street
            order.Street = order.Street.Replace("st.", "street").Replace("rd.", "road");

        }
    }
}