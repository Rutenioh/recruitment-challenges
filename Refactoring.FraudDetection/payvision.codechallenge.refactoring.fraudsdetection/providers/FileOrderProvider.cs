// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.factories;
using System;
using System.Collections.Generic;
using System.IO;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public class FileOrderProvider: IOrderProvider
    {
        private INormalizerFactory normalizerFactory;

        private string filePath;

        public FileOrderProvider(INormalizerFactory normalizerFactory, string filePath)
        {
            this.normalizerFactory = normalizerFactory;
            this.filePath = filePath;
        }

        /**
         * Get the orders from a file
         * 
         */
        public List<Order> getOrders()
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
                    Email = normalizerFactory.Create(OrderNormalizerFactory.MAIL).Normalize(items[2].ToLower()),
                    Street = normalizerFactory.Create(OrderNormalizerFactory.STREET).Normalize(items[3].ToLower()),
                    City = items[4].ToLower(),
                    State = normalizerFactory.Create(OrderNormalizerFactory.STATE).Normalize(items[5].ToLower()), 
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