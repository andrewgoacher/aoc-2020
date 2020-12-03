using System.Collections.Generic;
using NUnit.Framework;

namespace adventofcode.tests
{
    public class MapTests
    {
        const string mapInput = @"
            .#.#...
            ###..#.
            .......
            ###.##.
            ...#...";


        [Test]
        public void NewMapWithInconsistentDimensions_ThrowsInconsistentGridException()
        {
            var inconsistentMap = @"
            .#.#..
            ###..#.
            .......
            ###.##.
            ...#...";

            Assert.Throws<InconsistentGridException>(() => new Map(inconsistentMap));
        }

        [Test]
        public void ParseCreatesValidMap_HasCorrectWidth()
        {
            var map = new Map(mapInput);

            Assert.AreEqual(7, map.Width);
        }

        [Test]
        public void ParseCreatesValidMap_HasCorrectHeight()
        {
            var map = new Map(mapInput);

            Assert.AreEqual(5, map.Height);
        }

        [Test]
        public void TraverseMap_ChangesCurrentPosition()
        {
            var map = new Map(mapInput);
            Assert.AreEqual(0, map.X);
            Assert.AreEqual(0, map.Y);

            map.Traverse(4, 0);

            Assert.AreEqual(4, map.X);
            Assert.AreEqual(0, map.Y);
        }

        [Test]
        public void TraverseMap_LandsOnCorrectCell()
        {
            var map = new Map(mapInput);
            map.Traverse(0, 1);

            Assert.AreEqual('#', map.Current);
        }

        [Test]
        public void TraverseMap_StoresCellsTraversed()
        {
            var map = new Map(mapInput);
            map.Traverse(5, 1);

            var expectedList = new List<char>
            {
                '#','.','#','.','.','#'
            };

            Assert.AreEqual(expectedList, map.TraversedChars);
        }

        [Test]
        public void TraverseMap_TraversingHorizontally_Wraps()
        {
            var map = new Map(mapInput);
            map.Traverse(10, 0);

            Assert.AreEqual(3, map.X);
        }

        [Test]
        public void TraverseMap_TraversingVertically_StopsAtMax()
        {
            var map = new Map(mapInput);
            map.Traverse(0, 10);

            Assert.AreEqual(4, map.Y);
        }
    }
}