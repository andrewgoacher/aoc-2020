using Xunit;
using day12;

namespace tests
{
    public class DirectionTests
    {
        [Theory]
        [InlineData(Direction.North, true, 90, Direction.East)]
        [InlineData(Direction.North, false, 90, Direction.West)]
        [InlineData(Direction.North, true, 180, Direction.South)]
        public void ChangeDirectionReturnsCorrectDirection(Direction start, bool turnRight, int degrees, Direction expected)
        {
            Assert.Equal(expected, start.ChangeDirection(turnRight, degrees));
        }
    }
}