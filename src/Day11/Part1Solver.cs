using System.Collections.Generic;
using System.Linq;

namespace day11
{
    public static class Part1Solver
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
                if (i > 0) yield return original[i - 1, j];
                if (i < width) yield return original[i + 1, j];
                if (j > 0) yield return original[i, j - 1];
                if (j < height) yield return original[i, j + 1];

                if (i > 0 && j > 0) yield return original[i - 1, j - 1];
                if (i > 0 && j < height) yield return original[i - 1, j + 1];
                if (i < width && j > 0) yield return original[i + 1, j - 1];
                if (i < width && j < height) yield return original[i + 1, j + 1];
            }

            char ProcessSeated(IEnumerable<char> spots)
            {
                if (spots.Count(c => c.Equals(Occupied)) >= 4)
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