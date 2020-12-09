using System;

namespace Common
{
    public static class Output
    {
        public static void WriteChallenge<A, B>(int day, A a, B b)
        {
            Console.WriteLine($"Day {day:00}");
            Console.WriteLine($"\t\t {a}");
            Console.WriteLine($"\t\t {b}");
        }
    }
}
