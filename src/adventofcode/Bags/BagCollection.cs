using System.Collections;
using System.Collections.Generic;

namespace adventofcode.Bags
{
    public class BagCollection : IEnumerable<Bag>
    {
        public static BagCollection Parse(string[] inputs)
        {
            var dict = new Dictionary<string, Bag>();

            foreach (var input in inputs)
            {
                var bag = Bag.Parse(input, dict);
                dict.Add(bag.Name, bag);
            }

            return new BagCollection(dict);
        }

        public IEnumerator<Bag> GetEnumerator()
        {
            return Bags.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }

        private IDictionary<string, Bag> Bags { get; }

        private BagCollection(IDictionary<string, Bag> collection)
        {
            Bags = collection;
        }

        public Bag this[string bag]
        {
            get { return Bags[bag]; }
        }
    }
}