using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode.Passports
{
    public class Passport : IPassport
    {
        private static readonly string[] eyeColors = new string[7] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        internal Passport(string eyeColor, string passportId, int expiryYear, string hairColor,
            int birthYear, int issueYear, int? countryId, IHeight height)
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

        public string EyeColor { get; }
        public string PassportId { get; }
        public int ExpiryYear { get; }
        public string HairColor { get; }
        public int BirthYear { get; }
        public int IssueYear { get; }
        public int? CountryId { get; }
        public IHeight Height { get; }

        public bool IsValid()
        {
            if (!IsInRange(BirthYear, 1920, 2002)) { return false; }
            if (!IsInRange(IssueYear, 2010, 2020)) { return false; }
            if (!IsInRange(ExpiryYear, 2020, 2030)) { return false; }
            if (!Regex.IsMatch(PassportId, @"\d{9}")) { return false; }
            if (!eyeColors.Contains(EyeColor)) { return false; }
            if (!Regex.IsMatch(HairColor, "#[0-9a-f]{6}")) { return false; }
            if (!Height.IsValid()) { return false;}

            return true;
        }

        private static bool IsInRange(int input, int min, int max)
        {
            return input >= min && input <= max;
        }
    }
}

//         public bool IsPresent()
//         {
//             var absent = (string.IsNullOrEmpty(EyeColor) ||
//                 string.IsNullOrEmpty(PassportId) ||
//                 string.IsNullOrEmpty(ExpiryYear) ||
//                 string.IsNullOrEmpty(HairColor) ||
//                 string.IsNullOrEmpty(BirthYear) ||
//                 string.IsNullOrEmpty(IssueYear) ||
//                 string.IsNullOrEmpty(Height));

//             return !absent;
//         }


//         public bool IsValid()
//         {
//             if (!IsPresent()) { return false; }

//         }


//     }
// }