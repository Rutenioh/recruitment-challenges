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

        public IOrderProvider orderProvider;
        public IFraudChecker fraudChecker;

        public FraudRadar(IOrderProvider orderProvider, IFraudChecker fraudChecker)
        {
            this.orderProvider = orderProvider;
            this.fraudChecker = fraudChecker;
        }


        public IEnumerable<FraudResult> Check()
        {

            List<Order> orders = orderProvider.getOrders();

            return fraudChecker.check(orders);
        }


            
    }
}