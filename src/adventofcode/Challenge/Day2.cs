using System;
using System.IO;
using System.Linq;
using adventofcode.Password;

namespace adventofcode.Challenge
{
    public class Day2 : IChallenge
    {
        public void Run()
        {
            var day_2_input = File.ReadAllLines("./content/day_2_input.txt");
            var day_2_part_1_output = day_2_input
                .Select(x => new SledCompanyPasswordToken(x))
                .Count(x => x.IsValid());

            var day_2_part_2_output = day_2_input
                .Select(x => new ToboggenPasswordToken(x))
                .Count(x => x.IsValid());

            Console.WriteLine("day 2:");
            Console.WriteLine($"\t\t {day_2_part_1_output}");
            Console.WriteLine($"\t\t {day_2_part_2_output}");
        }
    }
}