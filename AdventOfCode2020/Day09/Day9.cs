using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day9 : IDay
    {
        private const bool DEBUG = true;
        private int preambleLength;
        

        public void Execute(bool useTestInput = false)
        {
            string[] input;
            long output = 0;
            int invalidNumIndex = -1;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("Day9/TestInput.txt");

                preambleLength = 5;
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("Day9/Input.txt");

                preambleLength = 25;
            }

            Console.WriteLine("Part 1");

            var nums = input.ToList().Select(s => long.Parse(s)).ToList();

            for (int i = preambleLength; i < nums.Count; i++)
            {
                var numGood = false;
                var num = nums[i];

                var preamble = nums.GetRange(i - preambleLength, preambleLength);

                Console.WriteLine($"Starting search for {i}: {num}");

                for (int j = 0; j < preambleLength; j++)
                {
                    if (DEBUG)
                    {
                        Console.WriteLine($"Starting check for {j}: {preamble[j]}");
                    }

                    if (preamble[j] > num)
                    {
                        continue;
                    }

                    var subpreamble = preamble.GetRange(j + 1, preambleLength - j - 1);
                    
                    for (int k = 0; k < subpreamble.Count; k++)
                    {
                        if (DEBUG)
                        {
                            Console.WriteLine($"{preamble[j]} + {subpreamble[k]} = {preamble[j] + subpreamble[k]} ?= ({num}) NumGood? {preamble[j] + subpreamble[k] == num}");
                        }

                        if (preamble[j] + subpreamble[k] == num)
                        {
                            numGood = true;
                            break;
                        }
                    }

                    if (numGood)
                    {
                        break;
                    }
                }

                if (!numGood)
                {
                    output = num;
                    invalidNumIndex = i;
                    break;
                }
            }

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            if (invalidNumIndex == -1)
            {
                return;
            }

            Console.WriteLine("Part 2");

            output = 0;

            var invalidNum = nums[invalidNumIndex];
            var start = 0;
            var end = 1;

            var sum = nums.GetRange(start, end).Sum();
            Console.WriteLine($"Checking num range {start}-{start + end - 1}: {String.Join(", ", nums.GetRange(start, end))}. Sum: {sum} ({invalidNum})");

            while (sum != invalidNum)
            {
                if (sum < invalidNum)
                {
                    end++;
                }
                
                if (sum > invalidNum)
                {
                    start++;
                    end--;
                }

                if (start > invalidNumIndex || end > invalidNumIndex)
                {
                    break;
                }

                sum = nums.GetRange(start, end).Sum();
                Console.WriteLine($"Checking num range {start}-{start + end - 1}: {String.Join(", ", nums.GetRange(start, end))}. Sum: {sum} ({invalidNum})");
            }

            var finalRange = nums.GetRange(start, end);

            output = finalRange.Min() + finalRange.Max();

            Console.WriteLine($"This is the Part 2 Output: {output}");
            Console.WriteLine();
        }
    }
}
