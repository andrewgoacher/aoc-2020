using System.IO;
using CPU;

using static Common.Output;

var input = File.ReadAllLines("./day_8_input.txt");

var instructions = Parser.ParseAll(input);
var computer = new Computer(instructions);

while (computer.Run() == ProgramState.Running) ;
var part1 = computer.Accumulator;

var loopStart = computer.LoopStart.PCWhenExecuted;
var loopEnd = computer.LastExecutedInstruction.PCWhenExecuted;
var part2 = -1;

for (var i = loopStart; i < loopEnd; ++i)
{
    computer = new Computer(instructions);
    if (computer.RepairInstruction(i))
    {
        while (computer.Run() == ProgramState.Running) ;
        if (computer.LastRunState == ProgramState.CleanExit)
        {
            part2 = computer.Accumulator;
            break;
        }
    }
}

WriteChallenge(8, part1, part2);