using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode.Bags
{
    public class Bag
    {
        private const string bagPattern = @"([\w ]+) bags contain ([\d\w\, ]+)\.";
        private static readonly Regex bagParserRegex = new Regex(bagPattern);

        private const string childBagPattern = @"(\d+) ([\w ]+) bags?";
        private static readonly Regex childBagRegex = new Regex(childBagPattern);
        public static Bag Parse(string input)
        {
            var matches = bagParserRegex.Match(input);
            var name = matches.Groups[1].Captures[0].Value;
            var childComponents = matches.Groups[2].Captures[0].Value;

            if (childComponents.Equals("no other bags"))
            {
                return new Bag(name, 0, Enumerable.Empty<Bag>());
            }

            var childRaw = childComponents.Split(',');

            var children = childRaw.Select(ParseChild);

            return new Bag(name, 0, children);
        }

        private static Bag ParseChild(string input)
        {
            var matches = childBagRegex.Match(input);
            var count = Convert.ToInt32(matches.Groups[1].Captures[0].Value);
            var name = matches.Groups[2].Captures[0].Value;

            return new Bag(name, count, Enumerable.Empty<Bag>());
        }

        private Bag(string name, int count, IEnumerable<Bag> children)
        {
            Name = name;
            Count = count;
            Bags = children;
        }

        public string Name { get; }
        public int Count { get; }
        public IEnumerable<Bag> Bags { get; }

        public bool Contains(string bagType)
        {
            return Bags.Any(b => b.Name.Equals(bagType));
        }
    }
}