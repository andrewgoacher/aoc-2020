using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode.Challenge
{
    public class Day3 : IChallenge
    {
        public void Run()
        {
            var day_3_input = File.ReadAllText("./content/day_3_input.txt");
            var day_3_map = new Map(day_3_input);

            var day_3_part_1_output = RunPart1(day_3_map);
            var day_3_part_2_output = RunPart2(day_3_map);


            Console.WriteLine("day 3:");
            Console.WriteLine($"\t\t {day_3_part_1_output}");
            Console.WriteLine($"\t\t {day_3_part_2_output}");
        }

        private static (int, int)[] GetSlopes()
        {
            return new[] {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };
        }

        private static IEnumerable<int> GetCounts(Map map)
        {
            var counts = new List<int>();

            foreach (var tuple in GetSlopes())
            {
                var (x, y) = tuple;
                while (!map.FinishedTraversing)
                {
                    map.Traverse(x, y);
                }

                counts.Add(map.TraversedChars.Count(x => x.Equals('#')));
                map.Reset();
            }

            return counts;
        }

        private static long RunPart2(Map map)
        {
            var counts = GetCounts(map);

            var output = counts.Aggregate(0L, (acc, val) =>
            {
                if (acc == 0) { return val; }
                return val * acc;
            });

            return output;
        }

        private static int RunPart1(Map map)
        {
            while (!map.FinishedTraversing)
            {
                map.Traverse(3, 1);
            }

            var output = map.TraversedChars.Count(x => x.Equals('#'));
            map.Reset();

            return output;
        }
    }
}