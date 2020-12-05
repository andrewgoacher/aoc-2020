using adventofcode.Pass;
using NUnit.Framework;

namespace adventofcode.tests
{
    public class BoardingPassTests
    {
        [Test]
        public void BoardingPass_MoreThan10Chars_ThrowsInvalidPassException()
        {
            const string pass = "FBFBFBFBFBFBLRLRLRLRLRLR";
            Assert.Throws<InvalidPassException>(() => new BoardingPass(pass));
        }

        [Test]
        public void BoardingPass_LessThan10Chars_ThrowsInvalidPassException()
        {
            const string pass = "FBFBRLLR";
            Assert.Throws<InvalidPassException>(() => new BoardingPass(pass));
        }

        [Test]
        public void BoardingPass_First7CharsNotFB_ThrowsInvalidPassException()
        {
            const string pass = "FBFBLRLRLR";
            Assert.Throws<InvalidPassException>(() => new BoardingPass(pass));
        }

        [Test]
        public void BoardingPass_Last3CharsNotLR_ThrowsInvalidPassException()
        {
            const string pass = "FBFBFBFBFL";
            Assert.Throws<InvalidPassException>(() => new BoardingPass(pass));
        }

        [TestCase("FFFBBBFRRR", 119)]
        [TestCase("BFFFBBFRRR", 567)]
        [TestCase("BBFFBBFRLL", 820)]
        public void ForBoardingPass_GetID(string input, int expectedId)
        {
            var boardingPass = new BoardingPass(input);

            Assert.AreEqual(expectedId, boardingPass.SeatId);
        }
    }
}