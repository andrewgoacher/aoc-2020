using System;
using System.Diagnostics;

namespace day12
{
    public enum NavigationCommand
    {
        North,
        South,
        East,
        West,
        Forward,
        Left,
        Right
    }

    [DebuggerDisplay("{NavigationCommand} {Amount}")]
    public class Command
    {
        public Command(NavigationCommand nav, int amount)
        {
            NavigationCommand = nav;
            Amount = amount;
        }

        public NavigationCommand NavigationCommand {get;}
        public int Amount {get;}

        public static Command Parse(string command)
        {
            var navRaw = command[0];
            var amountRaw = command[1..];

            var nav = navRaw switch
            {
                'N' => NavigationCommand.North,
                'S' => NavigationCommand.South,
                'E' => NavigationCommand.East,
                'W' => NavigationCommand.West,
                'F' => NavigationCommand.Forward,
                'L' => NavigationCommand.Left,
                'R' => NavigationCommand.Right,
                _ => throw new ArgumentException()
            };

            return new Command(nav, Convert.ToInt32(amountRaw));
        }
    }
}