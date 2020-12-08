using System.Linq;
using adventofcode.CPU;
using NUnit.Framework;

namespace adventofcode.tests
{
    public class ComputerTests
    {
        [Test]
        public void NewComputerStartsWithEmptyProgramCounterAndAccumulator()
        {
            var comp = new Computer(Enumerable.Empty<(Operand, int)>().ToList());

            Assert.AreEqual(0, comp.Accumulator);
            Assert.AreEqual(0, comp.ProgramCounter);
        }

        [Test]
        public void ComputerWillRunUntilEndOfProgramEncountered()
        {
            var inputs = new[]
            {
                "acc +1",
                "jmp +2",
                "acc +1",
                "nop +2"
            };

            var instructions = Parser.ParseAll(inputs);
            var comp = new Computer(instructions);

            while(comp.Run());
            Assert.AreEqual(Operand.NOP, comp.LastInstruction.Operand);
        }

         [Test]
        public void ComputerWillRunUntilLoopDetected()
        {
            var inputs = new[]
            {
                "acc +1",
                "jmp +2",
                "acc +1",
                "jmp -2"
            };

            var instructions = Parser.ParseAll(inputs);
            var comp = new Computer(instructions);

            while(comp.Run());
            Assert.AreEqual(1, comp.Accumulator);
        }
    }
}