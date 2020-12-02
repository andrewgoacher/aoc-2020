using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode.Password
{
    public class SledCompanyPasswordToken
    {
        private const string regexPattern = @"(\d+)-(\d+) (\w): (\w+)";
        private static readonly Regex regex = new Regex(regexPattern);
        public SledCompanyPasswordToken(string input)
        {
            var match = regex.Match(input);
            Min = Convert.ToInt32(match.Groups[1].Captures[0].Value);
            Max = Convert.ToInt32(match.Groups[2].Captures[0].Value);
            PasswordCharacter = match.Groups[3].Captures[0].Value[0];
            Password = match.Groups[4].Captures[0].Value;
        }

        public int Min { get; }
        public int Max { get; }
        public char PasswordCharacter { get; }
        public string Password {get;}

        public bool IsValid()
        {
            var count = Password.Count(c => c.Equals(PasswordCharacter));

            return count >= Min && count <= Max;
        }
    }
}