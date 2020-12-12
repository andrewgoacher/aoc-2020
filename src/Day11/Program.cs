using System.IO;
using System.Linq;
using day11;
using static Common.Output;

var lines = File.ReadAllLines("./input.txt").ToArray();

var originalGrid = GridLoader.GetGrid(lines);

var part1 = Solver.CountEmptySeats(originalGrid);
var part2 = 0;

WriteChallenge(11, part1, part2);