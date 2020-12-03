using System;
using System.Linq;

namespace adventofcode
{
    public class Map
    {
        private char[,] _grid;

        public Map(string input)
        {
            var split = input
            .Split(new[] { '\r', '\n'}, System.StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToArray();

            Width = split[0].Length;
            Height = split.Length;

            _grid = new char[ Width, Height];

            for(var height = 0; height < Height; ++height)
            {
                var len = split[height].Length;
                if (Width != len)
                {
                    throw new InconsistentGridException();
                }

                for(var width = 0; width < Width; ++width)
                {
                    _grid[width, height] = split[height][width];
                }
            }
        }

        public int Width { get; }
        public int Height { get; }
    }

    public class InconsistentGridException : Exception {}
}