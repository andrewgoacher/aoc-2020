using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode
{
    public class InvalidInputedException : Exception { }
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

        public static Passport Parse(string input)
        {
            var parts = input.Split(new char[] { ' ', '\n', '\r' },
                System.StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 8)
            {
                throw new InvalidInputedException();
            }

            string eyeColor = null;
            string passportId = null;
            string expiryYear = null;
            string hairColor = null;
            string birthYear = null;
            string countryId = null;
            string height = null;
            string issueYear = null;

            foreach (var part in parts)
            {
                var (key, value) = GetComponents(part);
                switch (key)
                {
                    case "ecl": eyeColor = value; break;
                    case "pid": passportId = value; break;
                    case "eyr": expiryYear = value; break;
                    case "hcl": hairColor = value; break;
                    case "byr": birthYear = value; break;
                    case "iyr": issueYear = value; break;
                    case "cid": countryId = value; break;
                    case "hgt": height = value; break;
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
                    if (currentCollection.Any())
                    {
                        collectionOfLines.Add(string.Join('\n', currentCollection));
                        currentCollection.Clear();
                        continue;
                    }
                }

                currentCollection.Add(line);
            }

            if (currentCollection.Any())
            {
                collectionOfLines.Add(string.Join('\n', currentCollection));
                currentCollection.Clear();
            }

            return collectionOfLines
                .Select(x => Passport.Parse(x));
        }

        private Passport(string eyeColor, string passportId, string expiryYear, string hairColor,
            string birthYear, string issueYear, string countryId, string height)
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
            var invalid = (string.IsNullOrEmpty(EyeColor) ||
                string.IsNullOrEmpty(PassportId) ||
                string.IsNullOrEmpty(ExpiryYear) ||
                string.IsNullOrEmpty(HairColor) ||
                string.IsNullOrEmpty(BirthYear) ||
                string.IsNullOrEmpty(IssueYear) ||
                string.IsNullOrEmpty(Height));

            return !invalid;
        }

        public string EyeColor { get; }
        public string PassportId { get; }
        public string ExpiryYear { get; }
        public string HairColor { get; }
        public string BirthYear { get; }
        public string IssueYear { get; }
        public string CountryId { get; }
        public string Height { get; }
    }
}