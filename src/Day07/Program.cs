using System.IO;
using System.Linq;
using Bags;

using static Common.Output;

var input = File.ReadAllLines("./day_7_input.txt");
var bags = BagCollection.Parse(input);

var part1 = bags.Count(x => x.Contains("shiny gold"));

var shinyGoldBag = bags["shiny gold"];

var part2 = shinyGoldBag.GetTotalBags();

WriteChallenge(7, part1, part2);