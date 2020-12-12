using System;

namespace day12
{
    public class Waypoint
    {
        private int _x;
        private int _y;

        private int _shipX;
        private int _shipY;
         public int ManhattenDistance => Math.Abs(_shipX) + Math.Abs(_shipY);

        public Waypoint()
        {
            _x = 10;
            _y = -1;
        }

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
                case NavigationCommand.Left: Rotate(-amount); break;
                case NavigationCommand.Right: Rotate(amount); break;
                default: throw new ArgumentException();
            }
        }

        private void Rotate(int amount)
        {
            var calcX = _x - _shipX;
            var calcY = _y - _shipY;

            var radians = amount * (Math.PI / 180);

            var x = Math.Round((calcX * Math.Cos(radians)) - (calcY * Math.Sin(radians)));
            var y = Math.Round((calcY * Math.Cos(radians)) + (calcX * Math.Sin(radians)));

            _x = (int)x + _shipX;
            _y = (int)y + _shipY;
        }

        private void Move(int amount)
        {
            var diffX = _x - _shipX;
            var diffY = _y - _shipY;

            _shipX += (diffX * amount);
            _shipY += (diffY * amount);

            _x = _shipX + diffX;
            _y = _shipY + diffY;
        }
    }
}