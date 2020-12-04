namespace adventofcode.Passports
{
    public interface IHeight
    {
        bool IsValid();
        int Height {get;}
        string Measure {get;}
    }
}