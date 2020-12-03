using System;

namespace adventofcode
{
    public class Map
    {
        private char[,] _grid;

        public Map(string input)
        {
            var split = input.Split(new[] { '\r', '\n'}, System.StringSplitOptions.RemoveEmptyEntries);

            Width = split[0].Length;
            Height = split.Length;

            _grid = new char[Width,Height];

            for(var i = 0; i < split.Length; ++i)
            {
                var len = split[i].Length;
                if (Width != len)
                {
                    throw new InconsistentGridException();
                }
                
                for(var j = 0; j < split[i].Length; ++j)
                {
                    _grid[j,i] = split[i][j];
                }
            }
        }

        public int Width { get; }
        public int Height { get; }
    }

    public class InconsistentGridException : Exception {}
}