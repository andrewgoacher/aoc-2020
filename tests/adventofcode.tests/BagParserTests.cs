using System.Linq;
using adventofcode.Bags;
using NUnit.Framework;

namespace adventofcode.tests
{
    public class BagParserTests
    {
        [Test]
        public void AParsedBagWillHaveTheCorrectName()
        {
            const string input = "dotted black bags contain no other bags.";
            var bag = Bag.Parse(input);

            Assert.AreEqual("dotted black", bag.Name);
        }

        [Test]
        public void ABagThatContainsNoOtherBagWillNotHaveAnyChildBags()
        {
            const string input = "dotted black bags contain no other bags.";
            var bag = Bag.Parse(input);

            Assert.NotNull(bag);
            Assert.IsEmpty(bag.Bags);
        }

        [Test]
        public void ABagThatContainsOneOtherBagWillContainThatBag()
        {
            const string input = "bright white bags contain 1 shiny gold bag.";
            var bag = Bag.Parse(input);

            Assert.NotNull(bag);
            var innerBag = bag.Bags.Single();
            Assert.AreEqual("shiny gold", innerBag.Name);
        }

        [Test]
        public void ABagThatContainsOneOtherBagWillContainTheNumberOfBagsAllowed()
        {
            const string input = "bright white bags contain 1 shiny gold bag.";
            var bag = Bag.Parse(input);

            Assert.NotNull(bag);
            var innerBag = bag.Bags.Single();
            Assert.AreEqual(1, innerBag.Count);
        }

        [Test]
        public void ABagThatContainsMoreThanOneBagWillContainAllRequiredBags()
        {
            const string input = "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.";
            var bag = Bag.Parse(input);

            Assert.NotNull(bag);

            Assert.AreEqual(2, bag.Bags.Count());
        }

        [Test]
        public void ABagThatContainsMoreThanOneBagWillContainAllRequiredBagsByName()
        {
            const string input = "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.";
            var bag = Bag.Parse(input);

            Assert.NotNull(bag);

            Assert.True(bag.Contains("shiny gold"));
        }
    }
}