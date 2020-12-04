namespace adventofcode.Passports
{
    public class InvalidHeight : IHeight
    {
        public int Height => -1;

        public string Measure => "";

        public bool IsValid() => false;
    }
}