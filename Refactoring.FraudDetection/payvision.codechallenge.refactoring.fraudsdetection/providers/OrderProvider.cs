// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class OrderProvider: IOrderCreator
    {
        private INormalizer normalizer;

        public OrderProvider(INormalizer normalizer)
        {
            this.normalizer = normalizer;
        }

        /**
         * Get the orders from a file
         * 
         */
        public List<Order> getOrders(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            List<Order> orders = new List<Order>();
            foreach (var line in lines)
            {
                var items = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var order = new Order
                {
                    OrderId = ValidateInt(items[0]),
                    DealId = ValidateInt(items[1]),
                    Email = normalizer.NormalizeMail(items[2].ToLower()),
                    Street = normalizer.NormalizeStreet(items[3].ToLower()),
                    City = items[4].ToLower(),
                    State = normalizer.NormalizeState(items[5].ToLower()), 
                    ZipCode = items[6],
                    CreditCard = items[7]
                };

                orders.Add(order);
            }
            return orders;
        }

        public int ValidateInt(string value)
        {
            int parsedValue = 0;
            if (int.TryParse(value, out parsedValue))
            {
                return parsedValue;
            }
            else
            {
                throw new InvalidCastException(string.Format("Error parsing the value '{0}'", value));
            }
        }

    }
}