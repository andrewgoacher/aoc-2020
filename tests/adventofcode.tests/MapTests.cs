using NUnit.Framework;

namespace adventofcode.tests
{
    public class MapTests
    {
        const string mapInput = @"
            .#.#..
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
    }
}