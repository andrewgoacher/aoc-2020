using System;
using System.IO;
using System.Linq;
using adventofcode.Pass;

namespace adventofcode.Challenge
{
    public class Day05 : IChallenge
    {
        public void Run()
        {
            var day_5_input = File.ReadAllLines("./content/day_5_input.txt");

            var day_5_part_1_output = day_5_input
                .Select(x => new BoardingPass(x).SeatId)
                .OrderByDescending(x => x)
                .First();
            
            Console.WriteLine("day 5:");
            Console.WriteLine($"\t\t {day_5_part_1_output}");
            // Console.WriteLine($"\t\t {day_1_part_2_output}");
        }
    }
}