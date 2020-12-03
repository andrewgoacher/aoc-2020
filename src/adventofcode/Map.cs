using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    public class Map
    {
        private char[,] _grid;
        private List<char> _traversedCells = new List<char>();

        public Map(string input)
        {
            var split = input
            .Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToArray();

            Width = split[0].Length;
            Height = split.Length;

            X = Y = 0;

            _grid = new char[Width, Height];

            for (var height = 0; height < Height; ++height)
            {
                var len = split[height].Length;
                if (Width != len)
                {
                    throw new InconsistentGridException();
                }

                for (var width = 0; width < Width; ++width)
                {
                    _grid[width, height] = split[height][width];
                }
            }
        }

        public int Width { get; }
        public int Height { get; }

        public int X { get; private set; }
        public int Y { get; private set; }

        public char Current { get { return _grid[X, Y]; } }

        public IEnumerable<char> TraversedChars => _traversedCells;

        public bool FinishedTraversing { get; private set; }

        public void Traverse(int x, int y)
        {
            if (FinishedTraversing) { return; }
            if (X + x >= Width)
            {
                X = (X + x) % Width;
            }
            else
            {
                X += x;
            }

            if (Y + y >= Height) { FinishedTraversing = true; }
            if (!FinishedTraversing)
            {
                Y += y;
                _traversedCells.Add(Current);
            }
        }

        public void Reset()
        {
            X = 0;
            Y = 0;
            FinishedTraversing = false;
            _traversedCells.Clear();
        }
    }

    public class InconsistentGridException : Exception { }
}