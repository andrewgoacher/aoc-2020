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

            var day_4_part_1_output = PassportParser
                .ParseBatch(day_4_input);

            var day_4_part_1_count = day_4_part_1_output.Count(x => x is Passport);

            Console.WriteLine("day 4:");
            Console.WriteLine($"\t\t {day_4_part_1_count}");
            // Console.WriteLine($"\t\t {day_2_part_2_output}");
        }
    }
}