using System;
using System.Text.RegularExpressions;

namespace adventofcode.Password
{
    public class ToboggenPasswordToken
    {
        private const string regexPattern = @"(\d+)-(\d+) (\w): (\w+)";
        private static readonly Regex regex = new Regex(regexPattern);
        public ToboggenPasswordToken(string input)
        {
            var match = regex.Match(input);
            FirstIndex = Convert.ToInt32(match.Groups[1].Captures[0].Value) - 1;
            SecondIndex = Convert.ToInt32(match.Groups[2].Captures[0].Value) - 1;
            PasswordCharacter = match.Groups[3].Captures[0].Value[0];
            Password = match.Groups[4].Captures[0].Value;
        }

        public int FirstIndex { get; }
        public int SecondIndex { get; }
        public char PasswordCharacter { get; }
        public string Password { get; }

        public bool IsValid()
        {
            var first = Password[FirstIndex].Equals(PasswordCharacter);
            var second = Password[SecondIndex].Equals(PasswordCharacter);

            return  first ^ second;
        }

    }
}