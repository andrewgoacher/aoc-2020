namespace adventofcode.Passports
{
    public class HeightCM : IHeight
    {
        public HeightCM(int input)
        {
            Height = input;
        }

        public int Height {get;}
        public bool IsValid()
        {
            return Height >= 150 && Height <= 193;
        }
    }
}