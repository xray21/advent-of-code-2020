using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class Day5 : IDay
    {
        public void Execute(bool useTestInput = false)
        {
            string[] input;
            int output = 0;

            if (useTestInput)
            {
                Console.WriteLine("TEST");
                input = File.ReadAllLines("Day5/TestInput.txt");
            }
            else
            {
                Console.WriteLine("ACTUAL");
                input = File.ReadAllLines("Day5/Input.txt");
            }

            Console.WriteLine("Part 1");

            var seatIds = new List<int>();

            foreach (var s in input)
            {
                var row = s.Substring(0, 7).Replace("F", "0").Replace("B", "1");
                var seat = s.Substring(7).Replace("L", "0").Replace("R", "1");

                var rowNum = Convert.ToInt32(row, 2);
                var seatNum = Convert.ToInt32(seat, 2);

                var seatId = (rowNum * 8) + seatNum;

                Console.WriteLine($"Row {row}, Seat: {seat}, RowNum: {rowNum.ToString("D3")}, SeatNum: {seatNum}, SeatId: {seatId}");

                if (seatId > output)
                {
                    output = seatId;
                }

                seatIds.Add(seatId);
            }

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            Console.WriteLine("Part 2");

            var maxSeatId = output;

            output = 0;

            var missingSeatIds = new List<int>();

            for(int i = 0; i < maxSeatId; i++)
            {
                if (!seatIds.Contains(i))
                {
                    missingSeatIds.Add(i);
                }
            }

            Console.WriteLine($"Missing SeatIds: {String.Join(",", missingSeatIds)}");
            Console.WriteLine();
        }
    }
}
