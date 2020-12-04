namespace adventofcode.Passports
{
    public class HeightInches : IHeight
    {
        public HeightInches(int input)
        {
            Height = input;
        }

        public int Height {get;}
        public bool IsValid()
        {
            return Height >= 59 && Height <= 76;
        }
    }
}