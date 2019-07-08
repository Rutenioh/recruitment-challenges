// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class FraudRadar
    {

        public INormalizer normalizer;
        public IOrderCreator orderCreator;

        public FraudRadar(INormalizer normalizer, IOrderCreator orderCreator)
        {
            this.normalizer = normalizer;
            this.orderCreator = orderCreator;
        }


        public IEnumerable<FraudResult> Check(string filePath)
        {
            // READ FRAUD LINES
            var fraudResults = new List<FraudResult>();
            
            List<Order> orders = orderCreator.getOrders(filePath);

            // NORMALIZE
            foreach (var order in orders)
            {
                normalizer.Normalize(order);
            }

            // CHECK FRAUD
            for (int i = 0; i < orders.Count; i++)
            {
                var current = orders[i];
                bool isFraudulent = false;

                for (int j = i + 1; j < orders.Count; j++)
                {
                    isFraudulent = false;

                    if (current.DealId == orders[j].DealId
                        && current.Email == orders[j].Email
                        && current.CreditCard != orders[j].CreditCard)
                    {
                        isFraudulent = true;
                    }

                    if (current.DealId == orders[j].DealId
                        && current.State == orders[j].State
                        && current.ZipCode == orders[j].ZipCode
                        && current.Street == orders[j].Street
                        && current.City == orders[j].City
                        && current.CreditCard != orders[j].CreditCard)
                    {
                        isFraudulent = true;
                    }

                    if (isFraudulent)
                    {
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = orders[j].OrderId });
                    }
                }
            }

            return fraudResults;
        }
    }
}