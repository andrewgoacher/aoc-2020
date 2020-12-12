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
        public void TestSampleDataHasCorrectNumberOfOccupiedSeats_UsingPart1Solver()
        {
            var grid = GridLoader.GetGrid(
                sample_data.Split(new char[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
            var count = Part1Solver.CountEmptySeats(grid);

            Assert.Equal(37, count);
        }

        [Fact]
        public void TestSampleDataHasCorrectNumberOfOccupiedSeats_UsingPart2Solver()
        {
            var grid = GridLoader.GetGrid(
                sample_data.Split(new char[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
            var count = Part2Solver.CountEmptySeats(grid);

            Assert.Equal(26, count);
        }
    }
}