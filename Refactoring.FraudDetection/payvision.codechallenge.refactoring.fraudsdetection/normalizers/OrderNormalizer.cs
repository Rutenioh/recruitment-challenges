// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    /**
     * Normalizer class of orders
     */
    public class OrderNormalizer : INormalizer
    {
        public string NormalizeMail(string email)
        {
            //Normalize email
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });

        }

        public string NormalizeState(string state)
        {
            //Normalize state
            return state.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }

        public string NormalizeStreet(string street)
        {
            //Normalize street
            return street.Replace("st.", "street").Replace("rd.", "road");

        }
    }
}