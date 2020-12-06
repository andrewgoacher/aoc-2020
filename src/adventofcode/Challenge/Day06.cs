using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using adventofcode.Password;

namespace adventofcode.Challenge
{
    public class Day06 : IChallenge
    {
        private static IEnumerable<IEnumerable<string>> GetAllInputs(string[] inputs)
        {
            var collectionOfLines = new List<IEnumerable<string>>();
            var currentCollection = new List<string>();

            foreach (var line in inputs)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (currentCollection.Any())
                    {
                        var arr = new string[currentCollection.Count];
                        currentCollection.CopyTo(arr);
                        collectionOfLines.Add(arr);
                        currentCollection.Clear();
                        continue;
                    }
                }

                currentCollection.Add(line);
            }

            if (currentCollection.Any())
            {
                var arr = new string[currentCollection.Count];
                currentCollection.CopyTo(arr);
                collectionOfLines.Add(arr);
                currentCollection.Clear();
            }

            return collectionOfLines;
        }

        private static int CountSame(IEnumerable<string> input)
        {
            if (input.Count() == 1)
            {
                return input.Single().Length;
            }

            var list = new Dictionary<char, int>();

            foreach (var item in input)
            {
                foreach (var c in item.ToCharArray())
                {
                    if (!list.TryAdd(c, 1))
                    {
                        list[c] = list[c] + 1;
                    }
                }
            }

            return list.Where(kvp => kvp.Value == input.Count()).Count();
        }

        public void Run()
        {
            var input = File.ReadAllLines("./content/day_6_input.txt");
            var allInputs = GetAllInputs(input);
            var part_1_output = allInputs
                .Select(x => string.Join("", x).ToCharArray().Distinct().Count())
                .Sum();

            var part_2_output = allInputs
                .Select(x => CountSame(x))
                .Sum();

            Console.WriteLine("day 6:");
            Console.WriteLine($"\t\t {part_1_output}");
            Console.WriteLine($"\t\t {part_2_output}");
        }
    }
}