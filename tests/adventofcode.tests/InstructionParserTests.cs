using System;
using adventofcode.CPU;
using NUnit.Framework;

namespace adventofcode.tests
{
    public class InstructionParserTests
    {
        [TestCase("nop +3", Operand.NOP)]
        [TestCase("acc +3", Operand.ACC)]
        [TestCase("jmp +3", Operand.JMP)]
        public void ParsingInstructionContainsCorrectInstruction(string input, Operand expected)
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

        [Test]
        public void ParsingAllInstructionsWillReturnAListOfParsedInstructions()
        {
            var inputs = new[] 
            {
                "acc +1",
                "jmp +2",
                "acc +1",
                "nop +2"
            };

            var parsed = Parser.ParseAll(inputs);

            Assert.AreEqual(inputs.Length, parsed.Count);
        }
    }
}