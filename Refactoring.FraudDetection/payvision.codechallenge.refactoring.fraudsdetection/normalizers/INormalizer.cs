// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    public interface INormalizer
    {
        string NormalizeMail(string mail);

        string NormalizeStreet(string street);

        string NormalizeState(string state);
    }
}