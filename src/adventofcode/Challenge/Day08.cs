using System;
using System.IO;
using adventofcode.CPU;

namespace adventofcode.Challenge
{
    public class Day08 : IChallenge
    {
        public void Run()
        {
            var input = File.ReadAllLines("./content/day_8_input.txt");
            
            var instructions = Parser.ParseAll(input);
            var computer = new Computer(instructions);

            while(computer.Run() == ProgramState.Running);
            var part_1_output = computer.Accumulator;

            var loopStart = computer.LoopStart.PCWhenExecuted;
            var loopEnd = computer.LastExecutedInstruction.PCWhenExecuted;
            var part_2_output = -1;

            for(var i = loopStart; i< loopEnd; ++i)
            {
                computer = new Computer(instructions);
                if (computer.RepairInstruction(i))
                {
                    while(computer.Run() == ProgramState.Running);
                    if (computer.LastRunState == ProgramState.CleanExit)
                    {
                        part_2_output = computer.Accumulator;
                        break;
                    }
                }
            }

            Console.WriteLine("day 8:");
            Console.WriteLine($"\t\t {part_1_output}");
            Console.WriteLine($"\t\t {computer.Accumulator} ({computer.LastRunState})");
        }
    }
}