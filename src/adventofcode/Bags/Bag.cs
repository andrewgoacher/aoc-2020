using System;
using System.Collections.Generic;

namespace adventofcode.Bags
{
    public class Bag
    {
        public static Bag Parse(string input)
        {
            throw new NotImplementedException();
        }

        public string Name { get; }
        public int Count { get; }
        public IEnumerable<Bag> Bags { get; }

        public bool Contains(string bagType)
        {
            return false;
        }
    }
}