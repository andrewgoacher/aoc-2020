using System.IO;
using System.Linq;
using Pass;
using static Common.Output;

var input = File.ReadAllLines("./day_5_input.txt");

var seatIds = input
    .Select(x => new BoardingPass(x).SeatId)
    .OrderByDescending(x => x)
    .ToList();

var part1 =
    seatIds
    .First();

var range = Enumerable.Range(0, part1)
    .Select((_, index) => index);

var intersect = range.Except(seatIds);

var part2 = -1;
foreach (var seat in intersect)
{
    var seats = seatIds.Where(x => x == seat + 1 || x == seat - 1);
    if (seats.Count() == 2)
    {
        part2 = seat;
        break;

    }
}

WriteChallenge(5, part1, part2);