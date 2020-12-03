using System;
using System.IO;
using System.Linq;
using adventofcode;
using adventofcode.Password;

var day_1_input = File.ReadAllLines("./content/day_1_input.txt").Select(x => Convert.ToInt32(x));
var day_1_part_1_output = SumNumbers.GetMultipleOfTwoNumbers(day_1_input, 2020);
var day_1_part_2_output = SumNumbers.GetMultipleOfThreeNumbers(day_1_input, 2020);

var day_2_input = File.ReadAllLines("./content/day_2_input.txt");
var day_2_part_1_output = day_2_input
    .Select(x => new SledCompanyPasswordToken(x))
    .Count(x => x.IsValid());

var day_2_part_2_output = day_2_input
    .Select(x => new ToboggenPasswordToken(x))
    .Count(x => x.IsValid());

var day_3_input = File.ReadAllText("./content/day_3_input.txt");
var day_3_part_1_map = new Map(day_3_input);

while(!day_3_part_1_map.FinishedTraversing)
{
    day_3_part_1_map.Traverse(3, 1);
}

var day_3_part_1_output = day_3_part_1_map.TraversedChars.Count(x => x.Equals('#'));

Console.WriteLine("day 1:");
Console.WriteLine($"\t\t {day_1_part_1_output}");
Console.WriteLine($"\t\t {day_1_part_2_output}");

Console.WriteLine("day 2:");
Console.WriteLine($"\t\t {day_2_part_1_output}");
Console.WriteLine($"\t\t {day_2_part_2_output}");

Console.WriteLine("day 3:");
Console.WriteLine($"\t\t {day_3_part_1_output}");
// Console.WriteLine($"\t\t {day_2_part_2_output}");