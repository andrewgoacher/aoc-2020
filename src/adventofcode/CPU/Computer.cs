using System.Collections.Generic;

namespace adventofcode.CPU
{
    public class Computer
    {
        public int ProgramCounter {get; private set;}
        public int Accumulator {get; private set;}
        public Instruction LastInstruction {get; private set;}

        private IList<(Instruction, int)> _program;

        public Computer(IList<(Instruction, int)> program)
        {
            _program = program;
            ProgramCounter = 0;
            Accumulator = 0;
        }

        public bool Run()
        {
            var (instruction, count) = _program[ProgramCounter];
            switch (instruction)
            {
                case Instruction.NOP: break;
                case Instruction.ACC: 
                {
                    Accumulator += count;
                    ProgramCounter += 1;
                    break;
                }
                case Instruction.JMP: 
                {
                    ProgramCounter += count;
                    break;
                }
            }

            LastInstruction = instruction;
            return instruction != Instruction.NOP;
        }
    }
}