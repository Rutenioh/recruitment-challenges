// -----------------------------------------------------------------------
// <copyright file="BitCounter.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;

    public class PositiveBitCounter
    {
        private const int ZERO = 0;
        private const int BIT_1 = 1;

        public IEnumerable<int> Count(int input)
        {

            if (input < 0)
            {
                throw new ArgumentException();
            }
            return CountPositiveBit(input);
        }

        private IEnumerable<int> CountPositiveBit(int input)
        {
            List<int> result = new List<int>();
            int position = 0;
            int counts = 0;

            while (input != ZERO)
            {
                if ((input & 1) == BIT_1)
                {
                    result.Add(position);
                    counts++;
                }
                position++;
                input >>= BIT_1;
            }
            result.Insert(0, counts);
            return result; 
        }
    }
}