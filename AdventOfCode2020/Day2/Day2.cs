using System;
using System.IO;

namespace AdventOfCode2020
{
    public class Day2 : IDay
    {
        public void Execute(bool useTestInput = false)
        {
            string[] input;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("Day2/TestInput.txt");
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("Day2/Input.txt");
            }

            Console.WriteLine("Part 1");
            var numCorrect = 0;

            foreach (var s in input)
            {
                var numInstances = 0;

                var tokens = s.Split(new char[] { ' ' });

                var range = tokens[0].Split(new char[] { '-' });
                var lower = int.Parse(range[0]);
                var upper = int.Parse(range[1]);

                var letter = tokens[1].Replace(":", "")[0];

                var password = tokens[2];

                foreach (var c in password)
                {
                    if (c == letter)
                    {
                        numInstances++;
                    }
                }

                if (numInstances >= lower && numInstances <= upper)
                {
                    numCorrect++;
                }

                // Console.WriteLine($"Lower: {lower}\tUpper: {upper}\tletter: {letter}\tNumInstances: {numInstances.ToString("D2")}\tGood: {numInstances >= lower && numInstances <= upper}\t\tPassword: {password}\t");
            }

            Console.WriteLine($"This is the number of correct passwords: {numCorrect}");
            Console.WriteLine();

            Console.WriteLine("Part 2");

            numCorrect = 0;

            foreach (var s in input)
            {
                var tokens = s.Split(new char[] { ' ' });

                var range = tokens[0].Split(new char[] { '-' });
                var pos1 = int.Parse(range[0]);
                var pos2 = int.Parse(range[1]);

                var letter = tokens[1].Replace(":", "")[0];

                var password = tokens[2];

                var cpos1 = password[pos1 - 1];
                var cpos2 = password[pos2 - 1];

                if ((cpos1 == letter && cpos2 != letter) || (cpos1 != letter && cpos2 == letter))
                {
                    numCorrect++;
                }

                // Console.WriteLine($"Pos1: {pos1.ToString("D2")}\tPos2: {pos2.ToString("D2")}\tletter: {letter}\tChars: {cpos1} {cpos2}\tGood: {(cpos1 == letter && cpos2 != letter) || (cpos1 != letter && cpos2 == letter)}\t\tPassword: {password}\t");
            }

            Console.WriteLine($"This is the number of correct passwords: {numCorrect}");
            Console.WriteLine();
        }
    }
}
