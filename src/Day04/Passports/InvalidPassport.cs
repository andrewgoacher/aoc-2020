namespace Passports
{
    public class InvalidPassport : IPassport
    {
        public bool IsValid() => false;
    }
}