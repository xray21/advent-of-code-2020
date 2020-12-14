using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2020.Extensions;

namespace AdventOfCode2020
{
    public class Day11 : Day
    {
        public Day11() : base(11)
        {
        }

        public override void Execute(bool useTestInput = false)
        {
            int output = 0;

            var input = GetInput(useTestInput);
            var seatMatrix = new List<List<char>>();

            Console.WriteLine("Part 1");

            seatMatrix = ConvertInputToSeatMatrix(input);
            seatMatrix = ExecuteRules(seatMatrix);
            output = CalculateOccupiedSeats(seatMatrix);

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            Console.WriteLine("Part 2");

            seatMatrix = ConvertInputToSeatMatrix(input);
            seatMatrix = ExecuteRules(seatMatrix, true);
            output = CalculateOccupiedSeats(seatMatrix);

            Console.WriteLine($"This is the Part 2 Output: {output}");
            Console.WriteLine();
        }

        private void PrintMatrix (List<List<char>> seatMatrix)
        {
            var str = "";

            foreach (var row in seatMatrix)
            {
                foreach (var seat in row)
                {
                    str += seat;
                }

                str += '\n';
            }

            Console.WriteLine(str);
        }

        private List<List<char>> CloneMatrix (List<List<char>> seatMatrix)
        {
            var newList = new List<List<char>>();

            foreach (var row in seatMatrix)
            {
                var newRow = new List<char>();

                foreach (var seat in row)
                {
                    newRow.Add(seat);
                }

                newList.Add(newRow);
            }

            return newList;
        }

        private List<List<char>> ConvertInputToSeatMatrix(List<string> input)
        {
            var seatMatrix = new List<List<char>>();

            foreach (var s in input)
            {
                seatMatrix.Add(s.ToCharArray().ToList());
            }

            return seatMatrix;
        }

        private List<List<char>> ExecuteRules(List<List<char>> seatMatrix, bool isPart2 = false)
        {
            int requiredOccupied = isPart2 ? 5 : 4;

            var numSeatsChanged = 0;
            var round = 0;

            var nextSeatMatrix = CloneMatrix(seatMatrix);

            var adjacents = new List<int[]>();
            adjacents.Add(new int[2] { -1, -1 });
            adjacents.Add(new int[2] { -1, 0 });
            adjacents.Add(new int[2] { -1, 1 });
            adjacents.Add(new int[2] { 0, -1 });
            adjacents.Add(new int[2] { 0, 1 });
            adjacents.Add(new int[2] { 1, -1 });
            adjacents.Add(new int[2] { 1, 0 });
            adjacents.Add(new int[2] { 1, 1 });

            Console.Clear();
            Console.WriteLine("Starting Configuration");
            PrintMatrix(seatMatrix);

            while (true)
            {
                round++;
                numSeatsChanged = 0;

                Console.Clear();
                Console.WriteLine($"Round {round}...FIGHT.");

                for (var r = 0; r < seatMatrix.Count; r++)
                {
                    var row = seatMatrix[r];

                    for (var s = 0; s < row.Count; s++)
                    {
                        var seat = row[s];

                        if (seat == '.')
                        {
                            continue;
                        }

                        if (seat == '#')
                        {
                            // Don't even bother if we're in one of the corners, there will never be enough adjacents. 
                            if ((s == 0 || s == row.Count - 1) && (r == 0 || r == seatMatrix.Count))
                            {
                                // Console.WriteLine($"Skipping row {r}, seat {s}");
                                continue;
                            }

                            var numOccupied = 0;

                            foreach (var adjacent in adjacents)
                            {
                                var adjRow = r + adjacent[0];
                                var adjSeat = s + adjacent[1];

                                if (adjRow < 0 || adjRow >= seatMatrix.Count || adjSeat < 0 || adjSeat >= row.Count)
                                {
                                    continue;
                                }

                                var adjacentSeat = seatMatrix[adjRow][adjSeat];

                                if (isPart2)
                                {
                                    while (adjacentSeat == '.')
                                    {
                                        adjRow += adjacent[0];
                                        adjSeat += adjacent[1];

                                        if (adjRow < 0 || adjRow >= seatMatrix.Count || adjSeat < 0 || adjSeat >= row.Count)
                                        {
                                            break;
                                        }

                                        adjacentSeat = seatMatrix[adjRow][adjSeat];
                                    }
                                }

                                if (adjacentSeat == '#')
                                {
                                    numOccupied++;

                                    if (numOccupied == requiredOccupied)
                                    {
                                        break;
                                    }
                                }
                            }

                            if (numOccupied == requiredOccupied)
                            {
                                nextSeatMatrix[r][s] = 'L';
                                numSeatsChanged++;
                            }
                        }

                        if (seat == 'L')
                        {
                            var canChange = true;

                            foreach (var adjacent in adjacents)
                            {
                                var adjRow = r + adjacent[0];
                                var adjSeat = s + adjacent[1];

                                if (adjRow < 0 || adjRow >= seatMatrix.Count || adjSeat < 0 || adjSeat >= row.Count)
                                {
                                    continue;
                                }

                                var adjacentSeat = seatMatrix[adjRow][adjSeat];

                                if (isPart2)
                                {
                                    while (adjacentSeat == '.')
                                    {
                                        adjRow += adjacent[0];
                                        adjSeat += adjacent[1];

                                        if (adjRow < 0 || adjRow >= seatMatrix.Count || adjSeat < 0 || adjSeat >= row.Count)
                                        {
                                            break;
                                        }

                                        adjacentSeat = seatMatrix[adjRow][adjSeat];
                                    }
                                }

                                if (adjacentSeat == '#')
                                {
                                    canChange = false;
                                    break;
                                }
                            }

                            if (canChange)
                            {
                                nextSeatMatrix[r][s] = '#';
                                numSeatsChanged++;
                            }
                        }
                    }
                }

                seatMatrix = CloneMatrix(nextSeatMatrix);
                PrintMatrix(seatMatrix);

                if (numSeatsChanged == 0)
                {
                    break;
                }
            }

            return seatMatrix;
        }

        private int CalculateOccupiedSeats(List<List<char>> seatMatrix)
        {
            var occupiedSeats = 0;

            foreach (var row in seatMatrix)
            {
                foreach (var seat in row)
                {
                    if (seat == '#')
                    {
                        occupiedSeats++;
                    }
                }
            }

            return occupiedSeats;
        }
    }
}
