using System;
using System.IO;

namespace AdventOfCode2020
{
    public class Day1 : IDay
    {
        public void Execute(bool useTestInput = false)
        {
            string[] input;
 
            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("Day1/TestInput.txt");
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("Day1/Input.txt");
            }

            Console.WriteLine("Part 1");
            int s1 = 0, s2 = 0, s3 = 0;

            foreach (var n1 in input)
            {
                foreach (var n2 in input)
                {
                    var np1 = int.Parse(n1);
                    var np2 = int.Parse(n2);

                    if (np1 + np2 == 2020)
                    {
                        s1 = np1;
                        s2 = np2;
                        break;
                    }
                }

                if (s1 + s2 == 2020)
                {
                    break;
                }
            }

            Console.WriteLine($"The two numbers are {s1} and {s2}. Multiplied, they are {s1 * s2}.");
            Console.WriteLine();

            Console.WriteLine("Part 2");
            s1 = 0;
            s2 = 0;

            foreach (var n1 in input)
            {
                var np1 = int.Parse(n1);

                foreach (var n2 in input)
                {
                    var np2 = int.Parse(n2);

                    if (np1 + np2 >= 2020)
                    {
                        continue;
                    }

                    foreach (var n3 in input)
                    {
                        var np3 = int.Parse(n3);

                        if (np1 + np2 + np3 == 2020)
                        {
                            s1 = np1;
                            s2 = np2;
                            s3 = np3;
                            break;
                        }
                    }
                }

                if (s1 + s2 + s3 == 2020)
                {
                    break;
                }
            }

            Console.WriteLine($"The three numbers are {s1}, {s2}, and {s3}. Multiplied, they are {s1 * s2 * s3}.");
            Console.WriteLine();
        }
    }
}
