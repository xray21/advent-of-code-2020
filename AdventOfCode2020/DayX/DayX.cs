using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode2020.Extensions;

namespace AdventOfCode2020
{
    public class DayX : Day
    {
        public DayX() : base(0)
        {
        }

        public override void Execute(bool useTestInput = false)
        {
            int output = 0;

            var input = GetInput(useTestInput);

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
