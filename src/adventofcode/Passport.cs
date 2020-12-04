using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode
{
    public class Passport
    {
        private const string regexPattern = @"(\w+):([\d\w#]+)";
        private static readonly Regex regex = new Regex(regexPattern);

        private const string digitsPattern = @"(\d+)";
        private static readonly Regex digitsRegex = new Regex(digitsPattern);

        private static (string, string) GetComponents(string input)
        {
            var match = regex.Match(input);
            return (match.Groups[1].Captures[0].Value,
             match.Groups[2].Captures[0].Value);
        }

        private static int? TryConvert(string input)
        {
            if (int.TryParse(input, out var output))
            {
                return output;
            }

            return null;
        }

        private static int? GetHeight(string input)
        {
            var match = digitsRegex.Match(input);
            if (match.Groups.Count > 1)
            {
                return TryConvert(match.Groups[1].Captures[0].Value);
            }

            return null;
        }

        public static Passport Parse(string input)
        {
            var parts = input.Split(new char[] { ' ', '\n', '\r' },
                System.StringSplitOptions.RemoveEmptyEntries);
            string eyeColor = null;
            int passportId = -1;
            int expiryYear = -1;
            string hairColor = null;
            int birthYear = -1;
            int issueYear = -1;
            int? countryId = null;
            int height = -1;

            foreach (var part in parts)
            {
                var (key, value) = GetComponents(part);
                switch (key)
                {
                    case "ecl": eyeColor = value; break;
                    case "pid": passportId = TryConvert(value) ?? -1; break;
                    case "eyr": expiryYear = TryConvert(value) ?? -1; break;
                    case "hcl": hairColor = value; break;
                    case "byr": birthYear = TryConvert(value) ?? -1; break;
                    case "iyr": issueYear = TryConvert(value) ?? -1; break;
                    case "cid": countryId = TryConvert(value) ?? -1; break;
                    case "hgt": height = GetHeight(value) ?? -1; break;
                    default: throw new InvalidOperationException();
                }
            }

            return new Passport(eyeColor, passportId, expiryYear, hairColor,
                birthYear, issueYear, countryId, height);
        }

        public static IEnumerable<Passport> ParseBatch(string[] input)
        {
            var collectionOfLines = new List<string>();

            var currentCollection = new List<string>();
            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    collectionOfLines.Add(string.Join('\n', currentCollection));
                    currentCollection.Clear();
                    continue;
                }

                currentCollection.Add(line);
            }

            return collectionOfLines
                .Select(x => Passport.Parse(x));
        }

        private Passport(string eyeColor, int passportId, int expiryYear, string hairColor,
            int birthYear, int issueYear, int? countryId, int height)
        {
            EyeColor = eyeColor;
            PassportId = passportId;
            ExpiryYear = expiryYear;
            HairColor = hairColor;
            BirthYear = birthYear;
            IssueYear = issueYear;
            CountryId = countryId;
            Height = height;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(EyeColor))
            {
                return false;
            }

            if (string.IsNullOrEmpty(HairColor))
            {
                return false;
            }

            if (PassportId < 0) { return false; }
            if (ExpiryYear < 0) { return false; }
            if (BirthYear < 0) { return false; }
            if (IssueYear < 0) { return false; }
            if (Height < 0) { return false; }
            return true;
        }

        public string EyeColor { get; }
        public int PassportId { get; }
        public int ExpiryYear { get; }
        public string HairColor { get; }
        public int BirthYear { get; }
        public int IssueYear { get; }
        public int? CountryId { get; }
        public int Height { get; }
    }
}