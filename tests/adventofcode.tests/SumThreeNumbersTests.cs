using System;
using NUnit.Framework;

namespace adventofcode.tests
{
    public class SumThreeNumbersTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SumNumbers_ListIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SumNumbers.GetMultipleOfThreeNumbers(null, 1000));
        }

        [Test]
        public void SumNumbers_ListContainsLessThan3Numbers_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => SumNumbers.GetMultipleOfThreeNumbers(new [] { 1, 2 }, 1000));
        }

        [Test]
        public void SumNumbers_ListDoesNotContain2NumbersThatAddUpToRequiredNumber_ThrowNumbersNotFoundException()
        {
            Assert.Throws<NumberNotFoundException>(() => SumNumbers.GetMultipleOfThreeNumbers(new [] { 1, 3, 5, 7}, 12));
        }

        [Test]
        public void SumNumbers_Found2Numbers_ReturnsMultipliedValue()
        {
            var list = new [] { 1, 3, 5, 7};
            const int num = 11;
            const long expected = 21;

            var actual = SumNumbers.GetMultipleOfThreeNumbers(list, num);

            Assert.AreEqual(expected, actual);
        }
    }
}