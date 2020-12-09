using System;
using System.IO;
using System.Linq;

using static Common.Output;

var inputs = File
    .ReadAllLines("./input.txt")
    .Select(x => Convert.ToInt64(x))
    .ToArray();

var part1 = -1L;
var offendingIndex = -1;

for(var i = 25; i<inputs.Length; ++i)
{
    if (!Computes(inputs[(i-25)..i], inputs[i]))
    {
        part1 = inputs[i];
        offendingIndex = i;
        break;
    }
}

var part2 = -1L;

var counterStart = offendingIndex-1;
var total = -1L;

var range = inputs[0..offendingIndex];

while(part2 < 0) 
{
    total = part1;

    for(var i=counterStart; i >=0; --i) 
    {
        total -= range[i];
        if (total == 0) 
        {
            var answerRange = inputs[i..counterStart].OrderBy(x => x).ToArray();
            part2 = answerRange[0] + answerRange[^1];
        }
        else if (total < 0) 
        {
            counterStart = --counterStart;
            break;
        }
    }
}

WriteChallenge(9, part1, part2);

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