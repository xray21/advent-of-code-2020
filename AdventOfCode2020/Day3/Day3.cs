using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class Day3 : IDay
    {
        public void Execute(bool useTestInput = false)
        {
            string[] input;
            long output = 0;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("Day3/TestInput.txt");
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("Day3/Input.txt");
            }

            Console.WriteLine("Part 1");

            int x = 0, y = 0;
            int lineLength = input[0].Length;
            const char treeChar = '#';
            
            while (true)
            {
                y++;
                if (y >= input.Length)
                {
                    break;
                }

                x += 3;
                if (x > lineLength - 1)
                {
                    x -= lineLength;
                }

                var curChar = input[y][x];
                if (curChar == treeChar)
                {
                    output++;
                }

                //Console.WriteLine($"{x}, {y}: {curChar}");
            }

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            Console.WriteLine("Part 2");

            output = 1;
            

            var slopes = new List<List<int>>();
            slopes.Add(new List<int>() { 1, 1 });
            slopes.Add(new List<int>() { 3, 1 });
            slopes.Add(new List<int>() { 5, 1 });
            slopes.Add(new List<int>() { 7, 1 });
            slopes.Add(new List<int>() { 1, 2 });

            foreach (var slope in slopes)
            {
                var numTreesForSlope = 0;
                y = 0;
                x = 0;

                while (true)
                {
                    y += slope[1];
                    if (y >= input.Length)
                    {
                        break;
                    }

                    x += slope[0];
                    if (x > lineLength - 1)
                    {
                        x -= lineLength;
                    }

                    var curChar = input[y][x];
                    if (curChar == treeChar)
                    {
                        numTreesForSlope++;
                    }

                    //Console.WriteLine($"{x}, {y}: {curChar}");
                }

                Console.WriteLine($"{slope[0]}, {slope[1]}: {numTreesForSlope}");

                output *= numTreesForSlope;
            }
            
            Console.WriteLine($"This is the Part 2 Output: {output}");
            Console.WriteLine();
        }
    }
}
