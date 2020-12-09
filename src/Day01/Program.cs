using System;
using System.IO;
using System.Linq;
using static Common.Output;

var input = File.ReadAllLines("./day_1_input.txt")
    .Select(x => Convert.ToInt32(x))
    .ToArray();

var part1 = -1L;
var part2 = -1L;

for (var x = 0; x < input.Length; ++x)
{
    var firstNum = input[x];
    for (var y = 1; y < input.Length; ++y)
    {
        var secondNum = input[y];
        if (firstNum + secondNum == 2020)
        {
            part1 = (long)firstNum * secondNum;
            continue;
        }
        for (var z = 2; z < input.Length; ++z)
        {
            var thirdNum = input[z];

            if (firstNum + secondNum + thirdNum == 2020)
            {
                part2 = (long)firstNum * secondNum * thirdNum;
            }
        }
    }
}

WriteChallenge(1, part1, part2);