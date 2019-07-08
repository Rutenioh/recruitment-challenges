// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class OrderCreator: IOrderCreator
    {
        public OrderCreator()
        {
        }

        public List<Order> getOrders(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            List<Order> orders = new List<Order>();
            foreach (var line in lines)
            {
                var items = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var order = new Order
                {
                    OrderId = int.Parse(items[0]),
                    DealId = int.Parse(items[1]),
                    Email = items[2].ToLower(),
                    Street = items[3].ToLower(),
                    City = items[4].ToLower(),
                    State = items[5].ToLower(), 
                    ZipCode = items[6],
                    CreditCard = items[7]
                };

                orders.Add(order);
            }
            return orders;
        }
    }
}