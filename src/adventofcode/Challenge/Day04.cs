using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode.Challenge
{
    public class Day04 : IChallenge
    {
        public void Run()
        {
            var day_4_input = File.ReadAllLines("./content/day_4_input.txt");

            var day_4_part_1_output = Passport
                .ParseBatch(day_4_input)
                .Where(x => x!= null)
                .Count(x => x != null);

            Console.WriteLine("day 4:");
            Console.WriteLine($"\t\t {day_4_part_1_output}");
            // Console.WriteLine($"\t\t {day_2_part_2_output}");
        }
    }
}