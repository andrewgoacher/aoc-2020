using System;
using System.IO;
using System.Linq;
using adventofcode;

var day_1_input = File.ReadAllLines("./content/day_1_input.txt").Select(x => Convert.ToInt32(x));
var day_1_part_1_output = SumNumbers.GetMultipleOfTwoNumbers(day_1_input, 2020);

Console.WriteLine($"day 1: {day_1_part_1_output}");