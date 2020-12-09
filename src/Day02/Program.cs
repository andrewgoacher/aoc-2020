using System.IO;
using System.Linq;
using Password;
using static Common.Output;

var input = File.ReadAllLines("./day_2_input.txt");
var part1 = input
    .Select(x => new SledCompanyPasswordToken(x))
    .Count(x => x.IsValid());

var part2 = input
    .Select(x => new ToboggenPasswordToken(x))
    .Count(x => x.IsValid());

WriteChallenge(2, part1, part2);