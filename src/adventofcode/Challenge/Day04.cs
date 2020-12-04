using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using adventofcode.Passports;

namespace adventofcode.Challenge
{
    public class Day04 : IChallenge
    {
        public void Run()
        {
            var day_4_input = File.ReadAllLines("./content/day_4_input.txt");

            var output = PassportParser
                .ParseBatch(day_4_input);

            var day_4_part_1_count = output.Count(x => x is Passport);
            var day_4_part_2_count = output.Count(x => x.IsValid());

            Console.WriteLine("day 4:");
            Console.WriteLine($"\t\t {day_4_part_1_count}");
            Console.WriteLine($"\t\t {day_4_part_2_count}");
        }
    }
}