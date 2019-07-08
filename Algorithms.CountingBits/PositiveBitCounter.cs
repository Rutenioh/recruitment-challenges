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
        public IEnumerable<int> Count(int input)
        {

            if (input < 0)
            {
                throw new ArgumentException();
            }
            if (input == 0)
            {
                return new List<int>() { 0 };
            }

            return CountPositiveBit(input);
        }

        private IEnumerable<int> CountPositiveBit(int input)
        {
            List<int> result = new List<int>();
            int position = 0;
            int counts = 0;

            while (input != 0)
            {
                if ((input & 1) == 1)
                {
                    result.Add(position);
                    counts++;
                }
                position++;
                input >>= 1;
            }
            result.Insert(0, counts);
            return result; 
        }
    }
}