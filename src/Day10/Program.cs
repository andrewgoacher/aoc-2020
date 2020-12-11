using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Xunit;
using static Common.Output;

var jolts = File.ReadAllLines("./input.txt")
    .Select(x => Convert.ToInt32(x))
    .OrderBy(x => x)
    .ToArray();

var (count1Jolters, count3Jolters) = Runner.RunPart1(jolts);

var part1 = count1Jolters * count3Jolters;
var part2 = Runner.RunPart2(jolts);

WriteChallenge(10, part1, part2);

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

    private static int GetNumberOfViableRoutes(Span<int> jolts, int start, int end)
    {
        var len = end - start + 1;
        if (start + len > jolts.Length) 
        {
            len = jolts.Length - start;
        }

        var range = jolts.Slice(start, len);
        var a = range[0];
        var b = range[^1];

        if (a == b) return 1;

        var count = 0;

        for (var i = 0; i < range.Length - 1; ++i)
        {
            for (var j = i + 1; j < i+4; ++j)
            {
                if (j >= range.Length) continue;
                if (range[j] != b && range[j] - range[i] <= 3)
                {
                    count += 1;
                }
            }
        }

        return count + 1;
    }

    public static long RunPart2(IEnumerable<int> jolts)
    {
        var list = jolts.ToList();
        list.Insert(0, 0);

        var span = new Span<int>(list.ToArray());

        var pairs = new List<(int, int)>();
        for (var i = 1; i < span.Length; ++i)
        {
            var prev = span[i - 1];
            var curr = span[i];

            if (curr - prev == 3)
            {
                pairs.Add((i - 1, i));
            }
        }

        var counts = new List<int>();
        var prevMarker = 0;
        foreach (var pair in pairs)
        {
            var (first, second) = pair;
            var curr = prevMarker;
            prevMarker = second;

            if (first == 0 || curr == first) continue;
            counts.Add(GetNumberOfViableRoutes(span, curr, first));
        }
        counts.Add(GetNumberOfViableRoutes(span, prevMarker, span.Length));

        return counts.Aggregate(1L, (acc, curr) => acc * curr);
    }
}

public class Tests
{
    private static readonly int[] Input = new[]
    {
        28, 33, 18, 42, 31, 14,
        46, 20, 48, 47, 24, 23,
        49, 45, 19, 38, 39, 11,
        1, 32, 25, 35, 8, 17,
        7, 9,  4, 2, 34, 10, 3
    };

    [Fact]
    public void RunPart1_GivesCorrectValues()
    {
        var (a, b) = Runner.RunPart1(Input.OrderBy(x => x).ToArray());

        Assert.Equal(22, a);
        Assert.Equal(10, b);
    }

    [Theory]
    [InlineData(new[] {  1, 2, 3, 4 }, 7)]
    public void RunPart2_Tests(int[] arr, long expected)
    {
        var count = Runner.RunPart2(arr.OrderBy(x => x).ToArray());
        Assert.Equal(expected, count);
    }

    [Fact]
    public void RunPArt2_GivesCorrectValues()
    {
        var count = Runner.RunPart2(Input.OrderBy(x => x).ToArray());
        Assert.Equal(19208, count);
    }
}