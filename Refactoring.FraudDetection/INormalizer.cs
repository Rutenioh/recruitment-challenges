// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public interface INormalizer
    {
        void Normalize(Order order);
    }
}