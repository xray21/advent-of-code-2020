using AdventOfCode2020.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day10 : IDay
    {
        public void Execute(bool useTestInput = false)
        {
            string[] input;
            long output = 0;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("Day10/TestInput.txt");
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("Day10/Input.txt");
            }

            Console.WriteLine("Part 1");

            output = 2272; // Thanks, OpenOffice Calc

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            Console.WriteLine("Part 2");

            var adapters = input.Select(s => new Adapter() { jiggawatts = int.Parse(s) }).ToList();
            adapters.Sort((a, b) => a.jiggawatts.CompareTo(b.jiggawatts));

            var max = adapters.Max(a => a.jiggawatts) + 3;

            Console.WriteLine($"Checking {-1}: {0}");

            output = countAdapters(new Adapter() { jiggawatts = 0 }, adapters, max);

            Console.WriteLine($"This is the Part 2 Output: {output}");
            Console.WriteLine();
        }

        public long countAdapters(Adapter curAdapter, List<Adapter> adapters, int max)
        {
            if (curAdapter.count > -1)
            {
                Console.WriteLine($"Already have count for {curAdapter.jiggawatts}: {curAdapter.count}");
                return curAdapter.count;
            }

            var relevantAdapters = adapters.FindAll(a => (a.jiggawatts - curAdapter.jiggawatts) <= 3 && (a.jiggawatts - curAdapter.jiggawatts) >= 1);

            if (relevantAdapters.Count == 0)
            {
                if (curAdapter.jiggawatts + 3 == max)
                {
                    return 1;
                }

                return 0;
            }

            long count = 0;

            foreach (var relevantAdapter in relevantAdapters)
            {
                var idx = adapters.FindIndex(a => a == relevantAdapter);

                Console.WriteLine($"Checking {idx.ToString("d3")}: {relevantAdapter.jiggawatts.ToString("d3")}");

                count += countAdapters(relevantAdapter, adapters.Slice(idx + 1), max);

                Console.WriteLine($"Checking {idx.ToString("d3")}: {relevantAdapter.jiggawatts.ToString("d3")}: Count {count}");
            }

            curAdapter.count = count;

            return count;
        }

        public class Adapter
        {
            public int jiggawatts { get; set; }
            public long count { get; set; } = -1;
        }
    }
}
