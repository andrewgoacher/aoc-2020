using Xunit;
using day12;
using System.Linq;

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

    public class ShipTests
    {
        [Fact]
        public void SampleDataProducesCorrectManhattenDistance()
        {
            var raw = new[] { "F10", "N3", "F7", "R90", "F11" };
            var commands = raw.Select(Command.Parse);

            var ship = new Ship(Direction.East);
            foreach (var cmd in commands) { ship.ReceiveCommand(cmd); }

            Assert.Equal(25, ship.ManhattenDistance);
        }
    }
}