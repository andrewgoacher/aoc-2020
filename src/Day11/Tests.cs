using System;
using Xunit;

namespace day11
{
    public class Tests
    {
        private const string sample_data = @"
            #.##.##.##
            #######.##
            #.#.#..#..
            ####.##.##
            #.##.##.##
            #.#####.##
            ..#.#.....
            ##########
            #.######.#
            #.#####.##";

        [Fact]
        public void TestSampleDataHasCorrectNumberOfOccupiedSeats()
        {
            var grid = GridLoader.GetGrid(
                sample_data.Split(new char[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
            var count = Solver.CountEmptySeats(grid);

            Assert.Equal(37, count);
        }
    }
}