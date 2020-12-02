using adventofcode.Password;
using NUnit.Framework;

namespace adventofcode.tests
{
    public class PassworkTokenizerTests
    {
        [Test]
        public void SledCompanyTokenizerReturnsCorrectTokenForPath()
        {
            const string val = "1-2 a: abcdef";
            var token = new SledCompanyPasswordToken(val);

            Assert.AreEqual(1, token.Min);
            Assert.AreEqual(2, token.Max);
            Assert.AreEqual('a', token.PasswordCharacter);
            Assert.AreEqual("abcdef", token.Password);
        }

        [TestCase("1-2 a: aabcd", true)]
        [TestCase("1-2 a: abacad", false)]
        [TestCase("4-9 z: aazzzbcd", false)]
        [TestCase("3-6 e: aeaebeced", true)]
        public void SledCompanyPasswordToken_CheckIsValid_ReturnsIsValid(string passwordString, bool expected)
        {
            var token = new SledCompanyPasswordToken(passwordString);

            Assert.AreEqual(expected, token.IsValid());
        }

            [Test]
        public void ToboggenTokenizerReturnsCorrectTokenForPath()
        {
            const string val = "1-2 a: abcdef";
            var token = new ToboggenPasswordToken(val);

            Assert.AreEqual(0, token.FirstIndex);
            Assert.AreEqual(1, token.SecondIndex);
            Assert.AreEqual('a', token.PasswordCharacter);
            Assert.AreEqual("abcdef", token.Password);
        }

        [TestCase("1-2 a: aabcd", true)]
        [TestCase("1-2 a: xsabacad", false)]
        [TestCase("4-9 z: aazzzbcd", true)]
        [TestCase("3-6 e: aeaebeced", true)]
        public void ToboggenPasswordToken_CheckIsValid_ReturnsIsValid(string passwordString, bool expected)
        {
            var token = new ToboggenPasswordToken(passwordString);

            Assert.AreEqual(expected, token.IsValid());
        }
    }
}