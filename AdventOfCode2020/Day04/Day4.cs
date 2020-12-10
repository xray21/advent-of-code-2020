using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day4 : IDay
    {
        public void Execute(bool useTestInput = false)
        {
            string[] input;
            int output = 0;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("Day4/TestInput.txt");
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("Day4/Input.txt");
            }

            Console.WriteLine("Part 1");

            var requiredFields = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            // Organize the input into Passports
            var passports = new List<string>();
            var passportStr = "";

            foreach (var s in input)
            {
                if (s.Trim() == "")
                {
                    // Console.WriteLine($"Passport: {passportStr}");
                    passports.Add(passportStr);
                    passportStr = "";

                    continue;
                }

                passportStr += s.Trim() + " ";
            }

            // Handle the last one
            // Console.WriteLine($"Passport: {passportStr}");
            passports.Add(passportStr);

            // Now validate each passport
            foreach (var passport in passports)
            {
                var hasRequiredFields = new List<string>();
                var missingFields = new List<string>();

                foreach (var requiredField in requiredFields)
                {
                    if (passport.Contains(requiredField + ":"))
                    {
                        hasRequiredFields.Add(requiredField);
                    }
                    else
                    {
                        missingFields.Add(requiredField);
                    }
                }

                Console.WriteLine($"Has Fields: {String.Join(",", hasRequiredFields)}\t\tMissing Fields: {String.Join(",", missingFields)}\t\tPassport: {passport}");

                if (missingFields.Count == 0)
                {
                    output++;
                }
            }

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            Console.WriteLine("Part 2");

            output = 0;

            // Perform validation against each field in each passport
            foreach (var passport in passports)
            {
                var passportFields = passport.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var passportFieldsDict = new Dictionary<string, string>();

                foreach(var passportField in passportFields)
                {
                    var passportFieldPieces = passportField.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    passportFieldsDict[passportFieldPieces[0]] = passportFieldPieces[1];
                }

                var hasRequiredFields = new List<string>();
                var missingFields = new List<string>();

                foreach (var requiredField in requiredFields)
                {
                    if (!passportFieldsDict.ContainsKey(requiredField))
                    {
                        missingFields.Add(requiredField);
                        continue;
                    }

                    var value = passportFieldsDict[requiredField].ToLower();

                    var isValid = true;

                    // Now perform validation on the field
                    switch (requiredField)
                    {
                        case "byr":
                            if (value.Length != 4 || !int.TryParse(value, out int byr) || byr < 1920 || byr > 2020)
                            {
                                isValid = false;
                                missingFields.Add(requiredField);
                            }

                            break;
                        case "iyr":
                            if (value.Length != 4 || !int.TryParse(value, out int iyr) || iyr < 2010 || iyr > 2020)
                            {
                                isValid = false;
                                missingFields.Add(requiredField);
                            }

                            break;
                        case "eyr":
                            if (value.Length != 4 || !int.TryParse(value, out int eyr) || eyr < 2020 || eyr > 2030)
                            {
                                isValid = false;
                                missingFields.Add(requiredField);
                            }

                            break;
                        case "hgt":
                            if (value.EndsWith("cm") && (!int.TryParse(value.Replace("cm", ""), out int hgtcm) || hgtcm < 150 || hgtcm > 193))
                            {
                                isValid = false;
                                missingFields.Add(requiredField);
                            }
                            else if (value.EndsWith("in") && (!int.TryParse(value.Replace("in", ""), out int hgtin) || hgtin < 50 || hgtin > 76))
                            {
                                isValid = false;
                                missingFields.Add(requiredField);
                            }
                            else if (!value.EndsWith("cm") && !value.EndsWith("in"))
                            {
                                isValid = false;
                                missingFields.Add(requiredField);
                            }

                            break;
                        case "hcl":
                            var reggieHCL = new Regex("^[#][0-9a-f]{6}$");
                            if (!reggieHCL.IsMatch(value))
                            {
                                isValid = false;
                                missingFields.Add(requiredField);
                            }

                            break;
                        case "ecl":
                            var regexECL = new Regex("^amb$|^blu$|^brn$|^gry$|^grn$|^hzl$|^oth$");
                            if (!regexECL.IsMatch(value))
                            {
                                isValid = false;
                                missingFields.Add(requiredField);
                            }

                            break;
                        case "pid":
                            var regexPID = new Regex("^[0-9]{9}$");
                            if (!regexPID.IsMatch(value))
                            {
                                isValid = false;
                                missingFields.Add(requiredField);
                            }

                            break;
                        default:
                            Console.WriteLine($"How did you even get here: {requiredField}");
                            break;
                    }

                    if (isValid)
                    {
                        hasRequiredFields.Add(requiredField);
                    }
                }

                Console.WriteLine($"Has Fields: {String.Join(",", hasRequiredFields)}\t\tMissing Fields: {String.Join(",", missingFields)}\t\tPassport: {passport}");

                if (missingFields.Count == 0)
                {
                    output++;
                }
            }

            Console.WriteLine($"This is the Part 2 Output: {output}");
            Console.WriteLine();
        }
    }
}
