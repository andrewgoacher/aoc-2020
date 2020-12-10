using System;
using System.IO;
using System.Linq;
using Xunit;
using static Common.Output;

var jolts = File.ReadAllLines("./input.txt")
    .Select(x => Convert.ToInt32(x))
    .OrderBy(x => x)
    .ToArray();

var (count1Jolters, count3Jolters) = Runner.RunPart1(jolts);

var part1 = count1Jolters * count3Jolters;


WriteChallenge(10, part1, 0);

public class Runner
{
    public static (int, int) RunPart1(int[] jolts)
    {
        var count1Jolters = 0;
        var count3Jolters = 1;

        if (jolts[0] == 1)
        {
            count1Jolters += 1;
        }
        else if (jolts[0] == 3)
        {
            count3Jolters += 1;
        }

        for (var i = 1; i < jolts.Length; ++i)
        {
            if (jolts[i] - jolts[i - 1] == 1)
            {
                count1Jolters += 1;
            }
            else if (jolts[i] - jolts[i - 1] == 3)
            {
                count3Jolters += 1;
            }
        }

        return (count1Jolters, count3Jolters);
    }
}

public class Tests
{
    [Fact]
    public void RunPart1_GivesCorrectValues()
    {
        var inputs = new[]
        {
            28,
            33,
            18,
            42,
            31,
            14,
            46,
            20,
            48,
            47,
            24,
            23,
            49,
            45,
            19,
            38,
            39,
            11,
            1,
            32,
            25,
            35,
            8,
            17,
            7,
            9,
            4,
            2,
            34,
            10,
            3
        };

        var (a, b) = Runner.RunPart1(inputs.OrderBy(x => x).ToArray());

        Assert.Equal(22, a);
        Assert.Equal(10, b);
    }
}