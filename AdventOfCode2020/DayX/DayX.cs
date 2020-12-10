using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020.Classes
{
    public class DayX : IDay
    {
        public void Execute(bool useTestInput = false)
        {
            string[] input;
            int output = 0;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("DayX/TestInput.txt");
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("DayX/Input.txt");
            }

            Console.WriteLine("Part 1");

            // Insert Part 1 Solution Here

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            Console.WriteLine("Part 2");

            // Insert Part 2 Solution Here

            Console.WriteLine($"This is the Part 2 Output: {output}");
            Console.WriteLine();
        }
    }
}
