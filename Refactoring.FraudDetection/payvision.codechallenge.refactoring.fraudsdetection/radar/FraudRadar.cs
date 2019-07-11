// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class FraudRadar
    {

        public IOrderCreator orderCreator;
        public IFraudChecker fraudChecker;

        public FraudRadar(IOrderCreator orderCreator, IFraudChecker fraudChecker)
        {
            this.orderCreator = orderCreator;
            this.fraudChecker = fraudChecker;
        }


        public IEnumerable<FraudResult> Check(string filePath)
        {

            List<Order> orders = orderCreator.getOrders(filePath);

            return fraudChecker.check(orders);
        }


            
    }
}