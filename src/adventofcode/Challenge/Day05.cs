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

            var seatIds = day_5_input
                .Select(x => new BoardingPass(x).SeatId)
                .OrderByDescending(x => x)
                .ToList();

            var day_5_part_1_output =
                seatIds
                .First();

            var range = Enumerable.Range(0, day_5_part_1_output)
                .Select((_, index) => index);

            var intersect = range.Except(seatIds);

            var day_5_part_2_output = -1;
            foreach (var seat in intersect)
            {
                var seats = seatIds.Where(x => x == seat + 1 || x == seat - 1);
                if (seats.Count() == 2)
                {
                    day_5_part_2_output = seat;
                    break;

                }
            }

            Console.WriteLine("day 5:");
            Console.WriteLine($"\t\t {day_5_part_1_output}");
            Console.WriteLine($"\t\t {day_5_part_2_output}");
        }
    }
}