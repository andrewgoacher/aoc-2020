using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode.CPU
{
    public class Parser
    {
        public static (Instruction, int) Parse(string input)
        {
            var parts = input.Split(" ");
            if (parts.Length != 2) { throw new InvalidInputException(); }

            var op = parts[0] switch
            {
                "nop" => Instruction.NOP,
                "acc" => Instruction.ACC,
                "jmp" => Instruction.JMP,
                _ => throw new ArgumentException()
            };

            var count = Convert.ToInt32(parts[1]);

            return (op, count);
        }

        public static IList<(Instruction, int)> ParseAll(string[] inputs)
        {
            return inputs.Select(Parse).ToList();
        }
    }
}