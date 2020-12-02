using System;
using NUnit.Framework;

namespace adventofcode.tests
{
    public class SumTwoNumbersTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SumNumbers_ListIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SumNumbers.GetMultipleOfTwoNumbers(null, 1000));
        }

        [Test]
        public void SumNumbers_ListContainsLessThan2Numbers_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => SumNumbers.GetMultipleOfTwoNumbers(new [] { 1 }, 1000));
        }

        [Test]
        public void SumNumbers_ListDoesNotContain2NumbersThatAddUpToRequiredNumber_ThrowNumbersNotFoundException()
        {
            Assert.Throws<NumberNotFoundException>(() => SumNumbers.GetMultipleOfTwoNumbers(new [] { 1, 3, 5, 7}, 11));
        }

        [Test]
        public void SumNumbers_Found2Numbers_ReturnsMultipliedValue()
        {
            var list = new [] { 1, 3, 5, 7};
            const int num = 10;
            const long expected = 21;

            var actual = SumNumbers.GetMultipleOfTwoNumbers(list, num);

            Assert.AreEqual(expected, actual);
        }
    }
}