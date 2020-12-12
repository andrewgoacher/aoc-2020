using System.IO;
using System.Linq;
using day12;
using static Common.Output;

var commands = File.ReadAllLines("./input.txt")
    .Select(Command.Parse);

var ship = new Ship(Direction.East);
foreach (var cmd in commands) { ship.ReceiveCommand(cmd); }

var part1 = ship.ManhattenDistance;
var part2 = 0;

WriteChallenge(12, part1, part2);