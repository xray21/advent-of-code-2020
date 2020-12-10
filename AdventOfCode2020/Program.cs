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

            switch (dayNum)
            {
                case "1":
                    Console.WriteLine("Executing Day 1.");

                    var day1 = new Day1();
                    day1.Execute(true);
                    day1.Execute();

                    break;
                case "2":
                    Console.WriteLine("Executing Day 2.");

                    var day2 = new Day2();
                    day2.Execute(true);
                    day2.Execute();

                    break;

                case "3":
                    Console.WriteLine("Executing Day 3.\n");

                    var day3 = new Day3();
                    day3.Execute(true);
                    day3.Execute();

                    break;
                case "4":
                    Console.WriteLine("Executing Day 4.\n");

                    var day4 = new Day4();
                    day4.Execute(true);
                    day4.Execute();

                    break;
                case "5":
                    Console.WriteLine("Executing Day 5.\n");

                    var day5 = new Day5();
                    day5.Execute(true);
                    day5.Execute();

                    break;
                case "6":
                    Console.WriteLine("Executing Day 6.\n");

                    var day6 = new Day6();
                    day6.Execute(true);
                    day6.Execute();

                    break;
                case "7":
                    Console.WriteLine("Executing Day 7.\n");

                    var day7 = new Day7();
                    day7.Execute(true);
                    day7.Execute();

                    break;
                case "8":
                    Console.WriteLine("Executing Day 8.\n");

                    var day8 = new Day8();
                    day8.Execute(true);
                    day8.Execute();

                    break;
                case "9":
                    Console.WriteLine("Executing Day 9.\n");

                    var day9 = new Day9();
                    day9.Execute(true);
                    day9.Execute();

                    break;
                default:
                    Console.WriteLine($"{dayNum} is not a valid input");
                    break;
            }

            Console.Write("Press any key to close");
            Console.ReadKey();
        }
    }
}
