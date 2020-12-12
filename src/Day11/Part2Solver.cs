using System.Collections.Generic;
using System.Linq;

namespace day11
{
    public static class Part2Solver
    {
        const char Floor = '.';
        const char Empty = 'L';
        const char Occupied = '#';

        public static char[,] Permutate(char[,] original)
        {
            var width = original.GetUpperBound(0);
            var height = original.GetUpperBound(1);

            var grid = new char[width + 1, height + 1];

            for (var i = 0; i <= width; ++i)
            {
                for (var j = 0; j <= height; ++j)
                {
                    var c = original[i, j];
                    var spots = GetAdjacentSpots(i, j);
                    c = c switch
                    {
                        Floor => Floor,
                        Occupied => ProcessSeated(spots),
                        Empty => ProcessEmpty(spots),
                        _ => '.'
                    };

                    grid[i, j] = c;
                }
            }

            IEnumerable<char> GetAdjacentSpots(int i, int j)
            {
                yield return GetLeftSpot(i, j);
                yield return GetRightSpot(i, j);
                yield return GetTopSpot(i, j);
                yield return GetBottomSpot(i, j);

                yield return GetTopLeftSpot(i, j);
                yield return GetTopRightSpot(i, j);
                yield return GetBottomLeftSpot(i, j);
                yield return GetBottomRightSpot(i, j);
            }

            char GetBottomRightSpot(int i, int j)
            {
                if (i+1 > width || j+1 > height) { return Floor;}

                var i2 = i+1;
                var j2 = j+1;
                var spot = original[i2, j2];

                if (spot == Floor) 
                {
                    return GetBottomRightSpot(i2, j2);
                }

                return spot;
            }

            char GetBottomLeftSpot(int i, int j)
            {
                if (i - 1 < 0 || j + 1 > height) { return Floor; }
                var i2 = i - 1;
                var j2 = j + 1;

                var spot = original[i2, j2];
                if (spot == Floor)
                {
                    return GetBottomLeftSpot(i2, j2);
                }

                return spot;
            }

            char GetTopRightSpot(int i, int j)
            {
                if (i + 1 > width || j - 1 < 0) { return Floor; }
                var i2 = i + 1;
                var j2 = j - 1;
                var spot = original[i2, j2];
                if (spot == Floor)
                {
                    return GetTopRightSpot(i2, j2);
                }

                return spot;
            }

            char GetTopLeftSpot(int i, int j)
            {
                if (i - 1 < 0 || j - 1 < 0) { return Floor; }
                var i2 = i - 1;
                var j2 = j - 1;
                var spot = original[i2, j2];
                if (spot == Floor)
                {
                    return GetTopLeftSpot(i2, j2);
                }

                return spot;
            }

            char GetBottomSpot(int i, int j)
            {
                if (j + 1 > height) { return Floor; }
                var j2 = j + 1;
                var spot = original[i, j2];
                if (spot == Floor)
                {
                    return GetBottomSpot(i, j2);
                }
                return spot;
            }

            char GetTopSpot(int i, int j)
            {
                if (j - 1 < 0) { return Floor; }
                var j2 = j - 1;
                var spot = original[i, j2];
                if (spot == Floor)
                {
                    return GetTopSpot(i, j2);
                }

                return spot;
            }

            char GetRightSpot(int i, int j)
            {
                if (i + 1 > width) { return Floor; }
                var i2 = i + 1;
                var spot = original[i2, j];
                if (spot == Floor)
                {
                    return GetRightSpot(i2, j);
                }
                return spot;
            }

            char GetLeftSpot(int i, int j)
            {
                if (i - 1 < 0) { return Floor; }
                var i2 = i - 1;
                var spot = original[i2, j];
                if (spot == Floor)
                {
                    return GetLeftSpot(i2, j);
                }
                return spot;
            }

            char ProcessSeated(IEnumerable<char> spots)
            {
                if (spots.Count(c => c.Equals(Occupied)) >= 5)
                {
                    return Empty;
                }

                return Occupied;
            }

            char ProcessEmpty(IEnumerable<char> spots)
            {
                if (spots.Count(c => c.Equals(Occupied)) == 0)
                {
                    return Occupied;
                }

                return Empty;
            }

            return grid;
        }

        public static char[,] Solve(char[,] original)
        {
            char[,] grid = original;
            char[,] previous = null;
            var equal = false;
            do
            {
                previous = grid;
                grid = Permutate(grid);
                equal = Equals(previous, grid);
            }
            while (!equal);

            return grid;
        }

        private static bool Equals(char[,] original, char[,] newArray)
        {
            if (original == null || newArray == null)
            {
                return false;
            }

            var originalWidth = original.GetUpperBound(0);
            var originalHeight = original.GetUpperBound(1);

            var newWidth = newArray.GetUpperBound(0);
            var newHeight = newArray.GetUpperBound(1);

            if (originalWidth != newWidth && originalHeight != newHeight)
            {
                return false;
            }

            for (var i = 0; i <= originalWidth; ++i)
            {
                for (var j = 0; j <= originalHeight; ++j)
                {
                    if (original[i, j] != newArray[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static int CountEmptySeats(char[,] original)
        {
            var grid = Solve(original);
            var counter = 0;

            var width = original.GetUpperBound(0);
            var height = original.GetUpperBound(1);

            for (var i = 0; i <= width; ++i)
            {
                for (var j = 0; j <= height; ++j)
                {
                    if (grid[i, j].Equals(Occupied))
                    {
                        counter += 1;
                    }
                }
            }

            return counter;
        }
    }
}