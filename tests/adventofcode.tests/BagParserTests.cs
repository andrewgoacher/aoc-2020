using System.Collections.Generic;
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
            var bag = Bag.Parse(input, new Dictionary<string, Bag>());

            Assert.AreEqual("dotted black", bag.Name);
        }

        [Test]
        public void ABagThatContainsNoOtherBagWillNotHaveAnyChildBags()
        {
            const string input = "dotted black bags contain no other bags.";
            var bag = Bag.Parse(input, new Dictionary<string, Bag>());

            Assert.NotNull(bag);
            Assert.IsEmpty(bag.Bags);
        }

        [Test]
        public void ABagThatContainsOneOtherBagWillContainThatBag()
        {
            const string input = "bright white bags contain 1 shiny gold bag.";
            var bag = Bag.Parse(input, new Dictionary<string, Bag>());

            Assert.NotNull(bag);
            var innerBag = bag.Bags.Single();
            Assert.AreEqual("shiny gold", innerBag.Name);
        }

        [Test]
        public void ABagThatContainsOneOtherBagWillContainTheNumberOfBagsAllowed()
        {
            const string input = "bright white bags contain 1 shiny gold bag.";
            var bag = Bag.Parse(input, new Dictionary<string, Bag>());

            Assert.NotNull(bag);
            var innerBag = bag.Bags.Single();
            Assert.AreEqual(1, innerBag.Count);
        }

        [Test]
        public void ABagThatContainsMoreThanOneBagWillContainAllRequiredBags()
        {
            const string input = "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.";
            var bag = Bag.Parse(input, new Dictionary<string, Bag>());

            Assert.NotNull(bag);

            Assert.AreEqual(2, bag.Bags.Count());
        }

        [Test]
        public void ABagThatContainsMoreThanOneBagWillContainAllRequiredBagsByName()
        {
            const string input = "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.";
            var bag = Bag.Parse(input, new Dictionary<string, Bag>());

            Assert.NotNull(bag);

            Assert.True(bag.Contains("shiny gold"));
        }

        [Test]
        public void BagCollectionCanParseMultipleBagRules()
        {
            var inputs = new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",
            };

            var collection = BagCollection.Parse(inputs);

            Assert.NotNull(collection);

            Assert.NotNull(collection["light red"]);
        }

        [Test]
        public void BagCollectionCanFindAllBagsContained()
        {
            var inputs = new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",
            };

            var collection = BagCollection.Parse(inputs);

            var count = collection.Count(x => x.Contains("shiny gold"));
            Assert.AreEqual(4, count);
        }
    }
}