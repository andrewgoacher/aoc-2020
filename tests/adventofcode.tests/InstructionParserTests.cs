using System;
using adventofcode.CPU;
using NUnit.Framework;

namespace adventofcode.tests
{
    public class InstructionParserTests
    {
        [TestCase("nop +3", Instruction.NOP)]
        [TestCase("acc +3", Instruction.ACC)]
        [TestCase("jmp +3", Instruction.JMP)]
        public void ParsingInstructionContainsCorrectInstruction(string input, Instruction expected)
        {
            var (instruction, _) = Parser.Parse(input);

            Assert.AreEqual(expected, instruction);
        }

        [TestCase("nop +3", 3)]
        [TestCase("acc -3", -3)]
        [TestCase("jmp 0", 0)]
        public void ParsingInstructionContainsCorrectIncrement(string input, int expected)
        {
            var (_, increment) = Parser.Parse(input);

            Assert.AreEqual(expected, increment);
        }

        [Test]
        public void UnknownInstructionThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Parser.Parse("fck +3"));
        }

        [Test]
        public void InstructionWithMoreThan2PartsWillThrowInvalidInputException()
        {
            Assert.Throws<InvalidInputException>(() => Parser.Parse("jmp + 3"));
        }
    }
}