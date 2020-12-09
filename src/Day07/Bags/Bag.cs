using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bags
{
    public class Bag
    {
        private const string bagPattern = @"([\w ]+) bags contain ([\d\w\, ]+)\.";
        private static readonly Regex bagParserRegex = new Regex(bagPattern);

        private const string childBagPattern = @"(\d+) ([\w ]+) bags?";
        private static readonly Regex childBagRegex = new Regex(childBagPattern);

        private readonly IDictionary<string, Bag> allBags;
        public static Bag Parse(string input, IDictionary<string, Bag> allBags)
        {
            var matches = bagParserRegex.Match(input);
            var name = matches.Groups[1].Captures[0].Value;
            var childComponents = matches.Groups[2].Captures[0].Value;

            if (childComponents.Equals("no other bags"))
            {
                return new Bag(name, 0, Enumerable.Empty<Bag>(), allBags);
            }

            var childRaw = childComponents.Split(',');

            var children = childRaw.Select(x => ParseChild(x, allBags));

            return new Bag(name, 0, children, allBags);
        }

        private static Bag ParseChild(string input, IDictionary<string, Bag> allBags)
        {
            var matches = childBagRegex.Match(input);
            var count = Convert.ToInt32(matches.Groups[1].Captures[0].Value);
            var name = matches.Groups[2].Captures[0].Value;

            return new Bag(name, count, Enumerable.Empty<Bag>(), allBags);
        }

        private Bag(string name, int count, IEnumerable<Bag> children, IDictionary<string, Bag> allBags)
        {
            Name = name;
            Count = count;
            Bags = children;
            this.allBags = allBags;
        }

        public string Name { get; }
        public int Count { get; }
        public IEnumerable<Bag> Bags { get; }

        public bool Contains(string bagType)
        {
            foreach (var bag in Bags)
            {
                if (bag.Name.Equals(bagType))
                {
                    return true;
                }

                if (allBags.TryGetValue(bag.Name, out var linekdBag))
                {
                    if (linekdBag.Contains(bagType))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int GetTotalBags()
        {
          return RecursiveGetTotalBags(0);
        }

        private int RecursiveGetTotalBags(int externalBag)
        {
              if (!Bags.Any())
            {
                return 1;
            }

            var total = 0;

            foreach (var bag in Bags)
            {
                if (allBags.TryGetValue(bag.Name, out var linkedBag))
                {
                    total += (bag.Count * (linkedBag.RecursiveGetTotalBags(1)));
                }
            }

            return total + externalBag;
        }
    }
}