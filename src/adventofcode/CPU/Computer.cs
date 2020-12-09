using System.Collections.Generic;
using System.Linq;

namespace adventofcode.CPU
{
    public enum ProgramState
    {
        CleanExit,
        LoopExit,
        Running
    }
    public class Computer
    {
        public int ProgramCounter { get; private set; }
        public int Accumulator { get; private set; }
        public Instruction LastExecutedInstruction { get; private set; }
        public ProgramState LastRunState { get; private set; }
        private IList<Instruction> _program;
        
        public Instruction LoopStart { get; private set; }

        public Computer(IList<(Operand, int)> program)
        {
            _program = program.Select(x => new Instruction(x.Item1, x.Item2)).ToList();
            ProgramCounter = 0;
            Accumulator = 0;
        }

        public bool RepairInstruction(int pc)
        {
            var instruction = _program[pc];
            if (instruction.Operand == Operand.ACC)
            {
                return false;
            }

            instruction.ChangeOperand(
                instruction.Operand == Operand.JMP ?
                    Operand.NOP :
                    Operand.JMP);

                    return true;
        }

        public void Reset()
        {
            ProgramCounter = 0;
            Accumulator = 0;
            LastExecutedInstruction = null;

            foreach (var instruction in _program)
            {
                instruction.Reset();
            }
        }
        private ProgramState RunInternal()
        {
            if (ProgramCounter >= _program.Count) { return ProgramState.CleanExit; }
            var instruction = _program[ProgramCounter];
            var (operand, count, executed) = instruction;
            if (executed)
            {
                LoopStart = instruction;
                return ProgramState.LoopExit;
            }

            instruction.Execute(ProgramCounter);
            LastExecutedInstruction = instruction;
            switch (operand)
            {
                case Operand.NOP: ProgramCounter += 1; break;
                case Operand.ACC:
                    {
                        Accumulator += count;
                        ProgramCounter += 1;
                        break;
                    }
                case Operand.JMP:
                    {
                        ProgramCounter += count;
                        break;
                    }
            }

            return ProgramState.Running;
        }
        public ProgramState Run()
        {
            LastRunState = RunInternal();
            return LastRunState;
        }
    }
}