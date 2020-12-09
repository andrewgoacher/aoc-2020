using System;

namespace Common
{
    public static class Output
    {
        public static void WriteChallenge<A, B>(int day, A a, B b)
        {
            Console.WriteLine($"Day {day:00}");
            Console.WriteLine($"\t part1: {a}");
            Console.WriteLine($"\t part2: {b}");
        }
    }
}
