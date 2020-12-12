namespace day12
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public static class DirectionExtensions
    {
        public static Direction ChangeDirection(this Direction direction, bool right, int degrees)
        {
            var nextDirection = direction;
            var moves = degrees / 90;

            for (var i = 0; i < moves; ++i)
            {
                nextDirection = right ?
                 nextDirection.ChangeRight() :
                 nextDirection.ChangeLeft();
            }

            return nextDirection;
        }

        private static Direction ChangeLeft(this Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.West,
                Direction.East => Direction.North,
                Direction.South => Direction.East,
                Direction.West => Direction.South
            };
        }

        private static Direction ChangeRight(this Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North
            };
        }
    }
}