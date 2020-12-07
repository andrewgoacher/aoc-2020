using System;
using System.IO;
using System.Linq;
using adventofcode.Bags;

namespace adventofcode.Challenge
{
    public class Day07 : IChallenge
    {
        public void Run()
        {
            var input = File.ReadAllLines("./content/day_7_input.txt");
            var bags = BagCollection.Parse(input);

            var part_1_output = bags.Count(x => x.Contains("shiny gold"));

            var shinyGoldBag = bags["shiny gold"];

            var part_2_output = shinyGoldBag.GetTotalBags();

            Console.WriteLine("day 7:");
            Console.WriteLine($"\t\t {part_1_output}");
            Console.WriteLine($"\t\t {part_2_output}");
        }
    }
}