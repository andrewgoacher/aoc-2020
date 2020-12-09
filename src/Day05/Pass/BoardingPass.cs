using System.Linq;

namespace Pass
{
    public class BoardingPass
    {
        public BoardingPass(string input)
        {
            if (input.Length != 10)
            {
                throw new InvalidPassException();
            }

            var parts = input.ToCharArray();

            var rows = parts.Take(7);
            if (rows.All(r => r.Equals('F') || r.Equals('B')) == false)
            {
                throw new InvalidPassException();
            }

            var columns = parts.Skip(7);
            if (columns.All(c => c.Equals('L') || c.Equals('R')) == false)
            {
                throw new InvalidPassException();
            }

            Row = GetRow(rows.ToArray(), 0, 127);
            Column = GetColumn(columns.ToArray(), 0, 7);
        }

        public int Row { get; private set; }
        public int Column { get; private set; }

        public int SeatId => (Row * 8) +  Column;

        private static int GetRow(char[] fb, int rangeMin, int rangeMax)
        {
            if (rangeMax - rangeMin == 1)
            {
                return fb[0].Equals('F') ? rangeMin : rangeMax;
            }

            var mp = GetMidpoint(rangeMin, rangeMax);
            return fb[0] switch
            {
                'F' => GetRow(fb[1..], rangeMin, mp),
                'B' => GetRow(fb[1..], mp + 1, rangeMax),
                _ => throw new InvalidPassException()
            };
        }


        private static int GetColumn(char[] lr, int rangeMin, int rangeMax)
        {
            if (rangeMax - rangeMin == 1)
            {
                return lr[0].Equals('L') ? rangeMin : rangeMax;
            }

            var mp = GetMidpoint(rangeMin, rangeMax);
            return lr[0] switch
            {
                'L' => GetColumn(lr[1..], rangeMin, mp),
                'R' => GetColumn(lr[1..], mp + 1, rangeMax),
                _ => throw new InvalidPassException()
            };
        }

        private static int GetMidpoint(int min, int max)
        {
            return (min + max) / 2;
        }
    }
}