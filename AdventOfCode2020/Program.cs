using System;

namespace AdventOfCode2020
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2020");
            Console.WriteLine("------------------------");
            Console.Write("Enter Day: ");

            var dayNum = Console.ReadLine();
            IDay day = null;

            switch (dayNum)
            {
                case "1":  day = new Day1();  break;
                case "2":  day = new Day2();  break;
                case "3":  day = new Day3();  break;
                case "4":  day = new Day4();  break;
                case "5":  day = new Day5();  break;
                case "6":  day = new Day6();  break;
                case "7":  day = new Day7();  break;
                case "8":  day = new Day8();  break;
                case "9":  day = new Day9();  break;
                case "10": day = new Day10(); break;
                case "11": day = new Day11(); break;
                //case "12": day = new Day12(); break;
                //case "13": day = new Day13(); break;
                //case "14": day = new Day14(); break;
                //case "15": day = new Day15(); break;
                //case "16": day = new Day16(); break;
                //case "17": day = new Day17(); break;
                //case "18": day = new Day18(); break;
                //case "19": day = new Day19(); break;
                //case "20": day = new Day20(); break;
                //case "21": day = new Day21(); break;
                //case "22": day = new Day22(); break;
                //case "23": day = new Day23(); break;
                //case "24": day = new Day24(); break;
                //case "25": day = new Day25(); break;
                default: Console.WriteLine($"{dayNum} is not a valid input"); break;
            }

            if (day != null)
            {
                Console.WriteLine($"Executing Day {dayNum}.");
                day.Execute(true);
                day.Execute();
            }

            Console.Write("Press any key to close");
            Console.ReadKey();
        }
    }
}
