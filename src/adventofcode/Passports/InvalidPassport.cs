namespace adventofcode.Passports
{
    public class InvalidPassport : IPassport
    {
        public bool IsValid() => false;
    }
}