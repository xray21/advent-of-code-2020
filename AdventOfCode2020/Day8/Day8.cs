using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class Day8 : IDay
    {
        private List<Instruction> instructions;
        private bool foundInstruction = false;

        public void Execute(bool useTestInput = false)
        {
            string[] input;
            int output = 0;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("Day8/TestInput.txt");
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("Day8/Input.txt");
            }

            instructions = new List<Instruction>();
            foundInstruction = false;

            Console.WriteLine("Part 1");

            foreach (var s in input)
            {
                var instructionParts = s.Split(new char[] { ' ' });

                var instruction = new Instruction();
                instruction.type = instructionParts[0];
                instruction.num = int.Parse(instructionParts[1]);

                instructions.Add(instruction);
            }

            output = ExecuteInstructions();

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            Console.WriteLine("Part 2");

            foreach (var instruction in instructions)
            {
                if (instruction.type == "acc")
                {
                    continue;
                }

                ResetInstructions();

                var ogType = instruction.type;

                instruction.type = ogType == "nop" ? "jmp" : "nop";

                output = ExecuteInstructions(5);

                instruction.type = ogType;

                if (foundInstruction)
                {
                    break;
                }
            }

            Console.WriteLine($"This is the Part 2 Output: {output}");
            Console.WriteLine();
        }

        public int ExecuteInstructions(int allottedVisitsPerInstruction = 1)
        {
            var acc = 0;

            var i = 0;
            var currentInstruction = instructions[i];

            while (true)
            {
                Console.Write($"Instruction {i.ToString("d3")} {currentInstruction.type} {currentInstruction.num}");

                currentInstruction.timesVisited++;
                if (currentInstruction.timesVisited > allottedVisitsPerInstruction)
                {
                    Console.WriteLine("...let's get out of here. ");
                    break;
                }

                switch (currentInstruction.type)
                {
                    case "nop":
                        i++;
                        break;
                    case "jmp":
                        i += currentInstruction.num;
                        break;
                    case "acc":
                        i++;
                        acc += currentInstruction.num;
                        break;
                }

                Console.WriteLine($" | moving to {i} (current acc: {acc} | Times Visited: {currentInstruction.timesVisited}");

                if (i >= instructions.Count)
                {
                    foundInstruction = true;
                    break;
                }

                currentInstruction = instructions[i];
            }

            return acc;
        }

        private void ResetInstructions()
        {
            foreach(var instruction in instructions)
            {
                instruction.timesVisited = 0;
            }
        }
    }

    class Instruction
    {
        public string type { get; set; }
        public int num { get; set; }
        public int timesVisited { get; set; } = 0;
    }
}
