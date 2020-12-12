using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public abstract class Day : IDay
    {
        public int dayNum;

        public Day(int dayNum)
        {
            this.dayNum = dayNum;
        }

        public virtual void Execute(bool useTestInput = false)
        {
        }

        public List<string> GetInput(bool useTestInput)
        {
            List<string> input;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines($"Day{dayNum}/TestInput.txt").ToList();
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines($"Day{dayNum}/Input.txt").ToList();
            }

            return input;
        }
    }
}
