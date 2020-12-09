using System;
using System.IO;
using System.Linq;
using static Common.Output;

var input = File.ReadAllLines("./day_1_input.txt")
    .Select(x => Convert.ToInt32(x))
    .ToArray();

var part1 = GetMultipleOfTwoNumbers(input);
var part2 = GetMultipleOfThreeNumbers(input);

WriteChallenge(1, part1, part2);

static long GetMultipleOfTwoNumbers(int[] array)
{
    for (var x = 0; x < array.Length; ++x)
    {
        for (var y = 1; y < array.Length; ++y)
        {
            var firstNum = array[x];
            var secondNum = array[y];

            if (firstNum + secondNum == 2020)
            {
                return (long)firstNum * secondNum;
            }
        }
    }

    throw new InvalidOperationException();
}

static long GetMultipleOfThreeNumbers(int[] array)
{
    for (var x = 0; x < array.Length; ++x)
    {
        for (var y = 1; y < array.Length; ++y)
        {
            for (var z = 2; z < array.Length; ++z)
            {
                var firstNum = array[x];
                var secondNum = array[y];
                var thirdNum = array[z];

                if (firstNum + secondNum + thirdNum == 2020)
                {
                    return (long)firstNum * secondNum * thirdNum;
                }
            }
        }
    }

    throw new InvalidOperationException();
}