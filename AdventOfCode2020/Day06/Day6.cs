using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day6 : IDay
    {
        public void Execute(bool useTestInput = false)
        {
            string[] input;
            int output = 0;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("Day6/TestInput.txt");
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("Day6/Input.txt");
            }

            Console.WriteLine("Part 1");

            var groups = new List<HashSet<char>>();
            var group = new HashSet<char>();

            foreach (var s in input)
            {
                if (s.Trim() == "")
                {
                    Console.WriteLine($"Distinct Answers in Group {groups.Count + 1}: {String.Join(",", group)}\tTotal Thusfar: {groups.Select(g => g.Count).Sum() + group.Count}");
                    groups.Add(group);
                    group = new HashSet<char>();

                    continue;
                }

                foreach (var c in s)
                {
                    group.Add(c);
                }
            }

            // Handle last one
            Console.WriteLine($"Distinct Answers in Group {groups.Count + 1}: {String.Join(",", group)}\t\tFinal Total: {groups.Select(g => g.Count).Sum() + group.Count}");
            groups.Add(group);

            output = groups.Select(g => g.Count).Sum();

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            Console.WriteLine("Part 2");
            groups = new List<HashSet<char>>();
            group = new HashSet<char>();

            var canInitialize = true;

            foreach (var s in input)
            {
                if (s.Trim() == "")
                {
                    Console.WriteLine($"In group {groups.Count + 1}, these had all Yes answers: {String.Join(",", group)}\tTotal Thusfar: {groups.Select(g => g.Count).Sum() + group.Count}");
                    groups.Add(group);
                    group = new HashSet<char>();

                    canInitialize = true;

                    continue;
                }

                // Initialize group with the first person's answers. 
                if (group.Count == 0 && canInitialize)
                {
                    foreach (var c in s)
                    {
                        group.Add(c);
                    }

                    canInitialize = false;

                    continue;
                }

                // Once we've initialized the group, we can use it to compare to the remaining answers in the group. 
                var filteredGroup = new HashSet<char>();

                foreach (var c in group)
                {
                    if (!s.Contains(c))
                    {
                        continue;
                    }

                    filteredGroup.Add(c);
                }

                group = filteredGroup;
            }

            Console.WriteLine($"In group {groups.Count + 1}, these had all Yes answers: {String.Join(",", group)}\tTotal Thusfar: {groups.Select(g => g.Count).Sum() + group.Count}");
            groups.Add(group);

            output = groups.Select(g => g.Count).Sum();

            Console.WriteLine($"This is the Part 2 Output: {output}");
            Console.WriteLine();
        }
    }
}
