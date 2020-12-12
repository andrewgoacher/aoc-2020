namespace day11
{
    public static class GridLoader
    {
        public static char[,] GetGrid(string[] inputs)
        {
            var width = inputs[0].Length;
            var height = inputs.Length;

            var grid = new char[width, height];

            for(var i=0;i<height; ++i)
            {
                var line = inputs[i];
                for(var j=0;j<width;++j)
                {
                    grid[j,i] = line[j];
                }
            }

            return grid;
        }
    }
}