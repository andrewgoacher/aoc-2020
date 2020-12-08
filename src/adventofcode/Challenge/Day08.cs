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

            computer.LastInstruction
                .ChangeOperand(computer.LastInstruction.Operand == Operand.JMP ?
                 Operand.NOP : 
                 Operand.JMP);

            computer.Reset();
            while(computer.Run()== ProgramState.Running);

            Console.WriteLine("day 8:");
            Console.WriteLine($"\t\t {part_1_output}");
            Console.WriteLine($"\t\t {computer.Accumulator} ({computer.LastRunState})");
        }
    }
}