using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode2020.Extensions;

namespace AdventOfCode2020
{
    public class Day12 : Day
    {
        public Day12() : base(12)
        {
        }

        public override void Execute(bool useTestInput = false)
        {
            int output = 0;
            var input = GetInput(useTestInput);

            Console.WriteLine("Part 1");
            var orientations = new Dictionary<int, char>();
            orientations[0]   = 'E';
            orientations[90]  = 'N';
            orientations[180] = 'W';
            orientations[270] = 'S';

            var x = 0;
            var y = 0;
            var orientation = 0;

            foreach (var s in input)
            {
                var action = s[0];
                var distance = int.Parse(s.Substring(1));

                if (action == 'F')
                {
                    action = orientations[orientation];
                }

                switch (action)
                {
                    case 'N':
                        y += distance; break;
                    case 'S':
                        y -= distance; break;
                    case 'E':
                        x += distance; break;
                    case 'W':
                        x -= distance; break;
                    case 'L':
                        orientation += distance; break;
                    case 'R':
                        orientation -= distance; break;
                }

                if (orientation < 0)
                {
                    orientation += 360;
                }

                if (orientation >= 360)
                {
                    orientation -= 360;
                }

                Console.WriteLine($"{x}, {y}, {orientation}");
            }

            output = Math.Abs(x) + Math.Abs(y);

            Console.WriteLine($"This is the Part 1 Output: {output}");
            Console.WriteLine();

            Console.WriteLine("Part 2");
            var wo = 'E';
            var ship = new Coord(0, 0);
            var w = new Coord(10, 1);

            foreach (var s in input)
            {
                Coord tw;

                var action = s[0];
                var distance = int.Parse(s.Substring(1));

                if (action == 'F')
                {
                    tw = Transform(w, wo);

                    ship.x += tw.x * distance;
                    ship.y += tw.y * distance;
                }

                switch (action)
                {
                    case 'N':
                        if (wo == 'N' || wo == 'S')
                        {
                            w.x += distance * (wo == 'S' ? -1 : 1);
                        }
                        else
                        {
                            w.y += distance * (wo == 'W' ? -1 : 1);
                        }

                        break;
                    case 'S':
                        if (wo == 'N' || wo == 'S')
                        {
                            w.x -= distance * (wo == 'S' ? -1 : 1);
                        }
                        else
                        {
                            w.y -= distance * (wo == 'W' ? -1 : 1);
                        }

                        break;
                    case 'E':
                        if (wo == 'N' || wo == 'S')
                        {
                            w.y += distance * (wo == 'N' ? -1 : 1);
                        }
                        else
                        {
                            w.x += distance * (wo == 'W' ? -1 : 1);
                        }

                        break;
                    case 'W':
                        if (wo == 'N' || wo == 'S')
                        {
                            w.y -= distance * (wo == 'N' ? -1 : 1);
                        }
                        else
                        {
                            w.x -= distance * (wo == 'W' ? -1 : 1);
                        }
                        break;
                    case 'L':
                    case 'R':
                        while (distance > 0)
                        {
                            switch (wo)
                            {
                                case 'E': wo = action == 'L' ? 'N' : 'S'; break;
                                case 'N': wo = action == 'L' ? 'W' : 'E'; break;
                                case 'W': wo = action == 'L' ? 'S' : 'N'; break;
                                case 'S': wo = action == 'L' ? 'E' : 'W'; break;
                            }

                            distance -= 90;
                        }

                        break;
                }

                tw = Transform(w, wo);
                Console.WriteLine($"{s}: Ship: {ship.x}, {ship.y} Waypoint: {tw.x}, {tw.y}, {wo}");
            }

            output = Math.Abs(ship.x) + Math.Abs(ship.y);

            Console.WriteLine($"This is the Part 2 Output: {output}");
            Console.WriteLine();
        }

        public class Coord
        {
            public int x { get; set; }
            public int y { get; set; }

            public Coord (int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public Coord Transform(Coord coord, char orientation)
        {
            var rCoord = new Coord(0, 0);

            if (orientation == 'E')
            {
                rCoord.x = coord.x;
                rCoord.y = coord.y;
            }

            if (orientation == 'N')
            {
                rCoord.x = -coord.y;
                rCoord.y = coord.x;
            }

            if (orientation == 'W')
            {
                rCoord.x = -coord.x;
                rCoord.y = -coord.y;
            }

            if (orientation == 'S')
            {
                rCoord.x = coord.y;
                rCoord.y = -coord.x;
            }

            return rCoord;
        }
    }
}
