using NUnit.Framework;

namespace adventofcode.tests
{
    public class PassworkTokenizerTests
    {
        [Test]
        public void TokenizerReturnsCorrectTokenForPath()
        {
            const string val = "1-2 a: abcdef";
            var token = new PasswordToken(val);

            Assert.AreEqual(1, token.Min);
            Assert.AreEqual(2, token.Max);
            Assert.AreEqual('a', token.PasswordCharacter);
            Assert.AreEqual("abcdef", token.Password);
        }

        [TestCase("1-2 a: aabcd", true)]
        [TestCase("1-2 a: abacad", false)]
        [TestCase("4-9 z: aazzzbcd", false)]
        [TestCase("3-6 e: aeaebeced", true)]
        public void PasswordToken_CheckIsValid_ReturnsIsValid(string passwordString, bool expected)
        {
            var token = new PasswordToken(passwordString);

            Assert.AreEqual(expected, token.IsValid());
        }
    }
}