using System.IO;
using System.Linq;
using Passports;
using static Common.Output;

var input = File.ReadAllLines("./day_4_input.txt");

var output = PassportParser
    .ParseBatch(input);

var part1 = output.Count(x => x is Passport);
var part2 = output.Count(x => x.IsValid());

WriteChallenge(4, part1, part2);