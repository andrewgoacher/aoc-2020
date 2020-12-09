using System;
using System.Collections.Generic;
using System.Linq;

namespace CPU
{
    public class Parser
    {
        public static (Operand, int) Parse(string input)
        {
            var parts = input.Split(" ");
            if (parts.Length != 2) { throw new InvalidInputException(); }

            var op = parts[0] switch
            {
                "nop" => Operand.NOP,
                "acc" => Operand.ACC,
                "jmp" => Operand.JMP,
                _ => throw new ArgumentException()
            };

            var count = Convert.ToInt32(parts[1]);

            return (op, count);
        }

        public static IList<(Operand, int)> ParseAll(string[] inputs)
        {
            return inputs.Select(Parse).ToList();
        }
    }
}