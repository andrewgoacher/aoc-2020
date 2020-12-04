using NUnit.Framework;
using adventofcode;
using System.Linq;
using adventofcode.Passports;

namespace adventofcode.tests
{
    public class PassportTests
    {
        const string invalidPassport = @"
            ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
            hgt:183cm
        ";

        [Test]
        public void ParsePassportMissingRequiredField_ReturnsInvalid()
        {
            var passport = PassportParser.Parse(invalidPassport);
            Assert.IsInstanceOf<InvalidPassport>(passport);
        }

        const string validPassportWithCountryId = @"
            ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
            byr:1937 iyr:2017 cid:147 hgt:183cm
        ";

        const string validPassportWithoutCountryId = @"
            ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
            byr:1937 iyr:2017 hgt:183cm
        ";

        [Test]
        public void ParsePassport_MoreThan8Fields_ThrowsInvalidInputException()
        {
            const string input = @"
            ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
            byr:1937 iyr:2017 cid:147 hgt:183cm avc:2323
        ";

            Assert.Throws<InvalidInputException>(() => PassportParser.Parse(input));
        }

        [Test]
        public void ParsePassportReturnsPassport()
        {
            var passport = PassportParser.Parse(validPassportWithCountryId);
            Assert.True(passport.IsValid());
        }

        [Test]
        public void ParsePassportMissingOptionalField_ReturnsPassport()
        {
            var passport = PassportParser.Parse(validPassportWithoutCountryId);
            Assert.True(passport.IsValid());
        }

        [Test]
        public void ParsedPassportContainsBirthyear()
        {
            var passport = PassportParser.Parse(validPassportWithCountryId) as Passport;
            Assert.AreEqual(1937, passport.BirthYear);
        }

        [Test]
        public void ParsedPassportContainsIssueYear()
        {
            var passport = PassportParser.Parse(validPassportWithCountryId) as Passport;
            Assert.AreEqual(2017, passport.IssueYear);
        }

        [Test]
        public void ParsedPassportContainsExpirationYear()
        {
            var passport = PassportParser.Parse(validPassportWithCountryId) as Passport;
            Assert.AreEqual(2020, passport.ExpiryYear);
        }

        [Test]
        public void ParsedPassportContainsHeight()
        {
            var passport = PassportParser.Parse(validPassportWithCountryId) as Passport;
            Assert.AreEqual(183, passport.Height.Height);
        }

        [Test]
        public void ParsedPassportContainsEyeColour()
        {
            var passport = PassportParser.Parse(validPassportWithCountryId) as Passport;
            Assert.AreEqual("gry", passport.EyeColor);
        }

        [Test]
        public void ParsedPassportContainsHairColour()
        {
            var passport = PassportParser.Parse(validPassportWithCountryId) as Passport;
            Assert.AreEqual("#fffffd", passport.HairColor);
        }

        [Test]
        public void ParsedPassportContainsPassportId()
        {
            var passport = PassportParser.Parse(validPassportWithCountryId) as Passport;
            Assert.AreEqual("860033327", passport.PassportId);
        }

        [Test]
        public void ParsedPassportContainsCountryId()
        {
            var passport = PassportParser.Parse(validPassportWithCountryId) as Passport;
            Assert.AreEqual(147, passport.CountryId);
        }

        [Test]
        public void ParsedPassport_WithMissingCountryId_DoesNotContainCountryId()
        {
            var passport = PassportParser.Parse(validPassportWithoutCountryId) as Passport;
            Assert.Null(passport.CountryId);
        }

        [Test]
        public void ParsedPassports_GetsCorrectCount()
        {
            const string input = @"
            ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
            byr:1937 iyr:2017 cid:147 hgt:183cm

            iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
            hcl:#cfa07d byr:1929

            hcl:#ae17e1 iyr:2013
            eyr:2024
            ecl:brn pid:760753108 byr:1931
            hgt:179cm

            hcl:#cfa07d eyr:2025 pid:166559648
            iyr:2011 ecl:brn hgt:59in
            ";

            var passports = PassportParser.ParseBatch(input.Split(new char[] { '\r', '\n' }));

            Assert.AreEqual(4, passports.Count());
        }

        [Test]
        public void ParsedPassports_GetsCorrectCountOfValidPassports()
        {
            const string input = @"
      ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in
            ";

            var passports = PassportParser.ParseBatch(input.Split(new char[] { '\r', '\n' }));

            Assert.AreEqual(2, passports.Count(x => x.IsValid()));
        }

        [Test]
        public void ParsedPassports_AllInvalid_ShouldAllReturnAsInvalid()
        {
            const string input = @"
            eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946

hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007
            ";

            var passports = PassportParser.ParseBatch(input.Split(new char[] { '\r', '\n' }));
            Assert.True(passports.All(x => !x.IsValid()));
        }

        [Test]
        public void ParsedPassports_AllValid_ShouldAllReturnAsValid()
        {
            const string input = @"
            pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f

eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719
            ";


            var passports = PassportParser.ParseBatch(input.Split(new char[] { '\r', '\n' }));
            Assert.True(passports.All(x => x.IsValid()));
        }
    }
}