using System.IO;
using System.Linq;
using day11;
using static Common.Output;

var lines = File.ReadAllLines("./input.txt").ToArray();

var originalGrid = GridLoader.GetGrid(lines);

var part1 = Part1Solver.CountEmptySeats(originalGrid);
var part2 = Part2Solver.CountEmptySeats(originalGrid);

WriteChallenge(11, part1, part2);