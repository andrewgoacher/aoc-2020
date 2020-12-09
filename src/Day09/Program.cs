using System;
using System.IO;
using System.Linq;

using static Common.Output;

var inputs = File
    .ReadAllLines("./input.txt")
    .Select(x => Convert.ToInt64(x))
    .ToArray();

var part1 = -1L;

for(var i = 25; i<inputs.Length; ++i)
{
    if (!Computes(inputs[(i-25)..i], inputs[i]))
    {
        part1 = inputs[i];
        break;
    }
}

WriteChallenge(9, part1, 0);

static bool Computes(long[] range, long expected)
{
    for(var i = 0; i < 25; ++i)
    {
        for(var j=1; j<25; ++j)
        {
            if (range[i] + range[j] == expected)
            {
                return true;
            }
        }
    }

    return false;
}