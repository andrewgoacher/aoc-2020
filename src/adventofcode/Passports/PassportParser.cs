using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode.Passports
{
    public static class PassportParser
    {
        private const string componentsRegexPattern = @"(\w+):([\d\w#]+)";
        private static readonly Regex componentsRegex = new Regex(componentsRegexPattern);
        private static (string, string) GetComponents(string input)
        {
            var match = componentsRegex.Match(input);
            return (match.Groups[1].Captures[0].Value,
             match.Groups[2].Captures[0].Value);
        }

        private const string heightRegexPattern = @"(\d+)(cm|in)";
        private static readonly Regex heightRegex = new Regex(heightRegexPattern);

        private static IHeight GetHeight(string input)
        {
            try
            {
                var matches = heightRegex.Match(input);
                var height = Convert.ToInt32(matches.Groups[1].Captures[0].Value);
                var measure = matches.Groups[2].Captures[0].Value;

                return measure switch
                {
                    "cm" => new HeightCM(height),
                    "in" => new HeightInches(height),
                    _ => new InvalidHeight()
                };
            }
            catch (Exception)
            {
                return new InvalidHeight();
            }
        }

        public static IPassport Parse(string input)
        {
            var parts = input.Split(new char[] { ' ', '\n', '\r' },
                          System.StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 8)
            {
                throw new InvalidInputException();
            }

            string eyeColor = null;
            string passportId = null;
            int expiryYear = -1;
            string hairColor = null;
            int birthYear = -1;
            int? countryId = null;
            IHeight height = null;
            int issueYear = -1;

            foreach (var part in parts)
            {
                var (key, value) = GetComponents(part);
                switch (key)
                {
                    case "ecl": eyeColor = value; break;
                    case "pid": passportId = value; break;
                    case "eyr":
                        {
                            if (!int.TryParse(value, out expiryYear))
                            {
                                return new InvalidPassport();
                            }
                            break;
                        }
                    case "hcl": hairColor = value; break;
                    case "byr":
                        {
                            if (!int.TryParse(value, out birthYear))
                            {
                                return new InvalidPassport();
                            }
                            break;
                        }
                    case "iyr":
                        {
                            if (!int.TryParse(value, out issueYear))
                            {
                                return new InvalidPassport();
                            }
                            break;
                        }
                    case "cid":
                        {
                            if (int.TryParse(value, out var cid))
                            {
                                countryId = cid;
                            }
                            break;
                        }
                    case "hgt":
                        {
                            height = GetHeight(value);
                            break;
                        }
                    default: throw new InvalidOperationException();
                }
            }

            if (string.IsNullOrEmpty(eyeColor) ||
                string.IsNullOrEmpty(passportId) ||
                string.IsNullOrEmpty(hairColor) ||
                height == null)
            {
                return new InvalidPassport();
            }

            if (expiryYear == -1 ||
                birthYear == -1 ||
                issueYear == -1)
            {
                return new InvalidPassport();
            }

            return new Passport(eyeColor, passportId, expiryYear,
                hairColor, birthYear, issueYear, countryId,
                height);
        }

        public static IEnumerable<IPassport> ParseBatch(string[] inputs)
        {
            var collectionOfLines = new List<string>();
            var currentCollection = new List<string>();

            foreach (var line in inputs)
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
                .Select(x => Parse(x));
        }
    }
}