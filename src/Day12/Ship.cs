using System;

namespace day12
{
    public class Ship
    {
        private Direction _heading;
        private int _x;
        private int _y;

        public Ship(Direction start)
        {
            _heading = start;
        }

        public int ManhattenDistance => Math.Abs(_x) + Math.Abs(_y);

        public void ReceiveCommand(Command command)
        {
            var amount = command.Amount;
            var nav = command.NavigationCommand;

            switch (nav)
            {
                case NavigationCommand.North: _y -= amount; break;
                case NavigationCommand.South: _y += amount; break;
                case NavigationCommand.West: _x -= amount; break;
                case NavigationCommand.East: _x += amount; break;
                case NavigationCommand.Forward: Move(amount); break;
                case NavigationCommand.Left: _heading = _heading.ChangeDirection(false, amount); break;
                case NavigationCommand.Right: _heading = _heading.ChangeDirection(true, amount); break;
                default: throw new ArgumentException();
            }
        }

        private void Move(int amount)
        {
            switch (_heading)
            {
                case Direction.North: _y -= amount; break;
                case Direction.South: _y += amount; break;
                case Direction.West: _x -= amount; break;
                case Direction.East: _x += amount; break;
                default: throw new ArgumentException();
            }
        }
    }
}