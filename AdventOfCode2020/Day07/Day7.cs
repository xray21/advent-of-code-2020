using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day7 : IDay
    {
        private Dictionary<BagNode, List<BagNode>> BagTypes;
        private string BagTypeToSearchFor;

        public Day7()
        {
            BagTypeToSearchFor = "shiny gold";
        }

        public void Execute(bool useTestInput = false)
        {
            string[] input;
            int output = 0;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("Day7/TestInput.txt");
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("Day7/Input.txt");
            }

            Console.WriteLine("Part 1");

            BagTypes = new Dictionary<BagNode, List<BagNode>>();

            // First, we need to parse this list of Bag Rules into the Dictionary so we can have every possible bag rule defined
            foreach (var s in input)
            {
                var bagNode = new BagNode();

                var bagRuleParts = s.Split(new string[] { " bags contain " }, StringSplitOptions.RemoveEmptyEntries);
                if (bagRuleParts.Length < 2 || bagRuleParts[1] == "no other bags.")
                {
                    continue;
                }

                bagNode.bagType = bagRuleParts[0].Trim();
                bagNode.count = -1;

                var bagNodes = new List<BagNode>();
                var bagTypeRules = bagRuleParts[1].Replace(".", "").Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
               
                foreach (var bagTypeRule in bagTypeRules)
                {
                    var bagTypeRuleParts = bagTypeRule.Split(new char[] { ' ' });

                    var bagTypeRuleBagNode = new BagNode();
                    bagTypeRuleBagNode.count = int.Parse(bagTypeRuleParts[0]);
                    bagTypeRuleBagNode.bagType = $"{bagTypeRuleParts[1]} {bagTypeRuleParts[2]}";

                    bagNodes.Add(bagTypeRuleBagNode);
                }

                BagTypes[bagNode] = bagNodes;
            }

            // Now that we have the bag types all parsed and shit, let's iterate through each one can get the number of shiny gold bags that we could hold in each one
            foreach (var bagNode in BagTypes.Keys)
            {
                if (bagNode.count > -1)
                {
                    continue;
                }

                bagNode.count = GetBagTypeCountByBagType(bagNode.bagType);
            }

            output = BagTypes.Keys.ToList().FindAll(bn => bn.count > 0 && bn.bagType != BagTypeToSearchFor).Count;

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            Console.WriteLine("Part 2");

            ResetCounts();
            output = GetBagTypeCountByBagType(BagTypeToSearchFor, true);

            Console.WriteLine($"This is the Part 2 Output: {output}");
            Console.WriteLine();
        }

        private int GetBagTypeCountByBagType(string bagType, bool calculateTotal = false)
        {
            Console.Write($"{bagType} ");

            var bagNode = BagTypes.Keys.ToList().Find(bn => bn.bagType == bagType);

            // If bag type doesn't exist, that means it can't contain any bags itself. Return 0.
            if (bagNode == null)
            {
                Console.WriteLine("is empty.");
                return calculateTotal ? 1 : 0;
            }
            
            // If the root bag node that we're looking at has already been calculated, just return count that back.
            if (bagNode.count > -1)
            {
                Console.WriteLine($"has already been calculated as {bagNode.count}");
                return bagNode.count;
            }

            // If the bag node that we're looking at is the bag type to search for, then return 1;
            if (bagNode.bagType == BagTypeToSearchFor && !calculateTotal)
            {
                Console.WriteLine("is the one we are looking for. 1.");
                return 1;
            }

            // If none of these above conditions are true, then we need to go deeper. 
            var count = 0;

            var bagNodeBagTypes = BagTypes[bagNode];

            Console.WriteLine($"bags contain {String.Join(", ", bagNodeBagTypes.Select(bnbt => $"{bnbt.count} {bnbt.bagType} bags").ToList())}.");

            foreach (var bagNodeBagType in bagNodeBagTypes)
            {
                count += GetBagTypeCountByBagType(bagNodeBagType.bagType, calculateTotal) * bagNodeBagType.count;
            }

            // Include itself
            if (calculateTotal && bagType != BagTypeToSearchFor)
            {
                count++;
            }

            Console.WriteLine($"{bagType} contains {count} bags.");

            bagNode.count = count;

            return count;
        }

        private void ResetCounts()
        {
            foreach (var bagNode in BagTypes.Keys)
            {
                bagNode.count = -1;
            }
        }
    }

    class BagNode
    {
        public int count { get; set; }
        public string bagType { get; set; }
    }
}
