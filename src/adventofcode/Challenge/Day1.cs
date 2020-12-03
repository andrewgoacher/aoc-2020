using System;
using System.IO;
using System.Linq;

namespace adventofcode.Challenge
{
    public class Day1 : IChallenge
    {
        public void Run()
        {
            var day_1_input = File.ReadAllLines("./content/day_1_input.txt")
                .Select(x => Convert.ToInt32(x));
            var day_1_part_1_output = SumNumbers.GetMultipleOfTwoNumbers(day_1_input, 2020);
            var day_1_part_2_output = SumNumbers.GetMultipleOfThreeNumbers(day_1_input, 2020);

            Console.WriteLine("day 1:");
            Console.WriteLine($"\t\t {day_1_part_1_output}");
            Console.WriteLine($"\t\t {day_1_part_2_output}");
        }
    }
}