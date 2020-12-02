using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    public static class SumNumbers
    {
        public static long GetMultipleOfTwoNumbers(IEnumerable<int> numbers, int sumValue)
        {
            if (numbers == null) { throw new ArgumentNullException(); }
            var array = numbers.ToArray();

            if (array.Length < 2) { throw new ArgumentException(); }

            for (var x = 0; x < array.Length; ++x)
            {
                for (var y = 1; y < array.Length; ++y)
                {
                    var firstNum = array[x];
                    var secondNum = array[y];

                    if (firstNum + secondNum == sumValue)
                    {
                        return (long)firstNum * secondNum;
                    }
                }
            }

            throw new NumberNotFoundException();
        }

        public static long GetMultipleOfThreeNumbers(IEnumerable<int> numbers, int sumValue)
        {
            if (numbers == null) { throw new ArgumentNullException(); }
            var array = numbers.ToArray();

            if (array.Length < 3) { throw new ArgumentException(); }

            for (var x = 0; x < array.Length; ++x)
            {
                for (var y = 1; y < array.Length; ++y)
                {
                    for (var z = 2; z < array.Length; ++z)
                    {
                        var firstNum = array[x];
                        var secondNum = array[y];
                        var thirdNum = array[z];

                        if (firstNum + secondNum + thirdNum == sumValue)
                        {
                            return (long)firstNum * secondNum * thirdNum;
                        }
                    }
                }
            }

            throw new NumberNotFoundException();
        }
    }
}