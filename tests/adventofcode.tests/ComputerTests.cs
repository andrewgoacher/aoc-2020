using adventofcode.CPU;
using NUnit.Framework;

namespace adventofcode.tests
{
    public class ComputerTests
    {
        [Test]
        public void NewComputerStartsWithEmptyProgramCounterAndAccumulator()
        {
            var comp = new Computer(null);

            Assert.AreEqual(0, comp.Accumulator);
            Assert.AreEqual(0, comp.ProgramCounter);
        }

        [Test]
        public void ComputerWillRunUntilNopEncountered()
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
            Assert.AreEqual(Instruction.NOP, comp.LastInstruction);
        }
    }
}