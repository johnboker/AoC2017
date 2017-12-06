using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Solutions
{
    public class Day03 : IDaySolution
    {
        public Day03() { }

        public void Solve(bool test = false)
        {
            Solve1(test);
            Solve2(test);
        }

        private void Solve1(bool test)
        {
            var input = 361527;
            var minSq = (int)Math.Sqrt(input);

            var diff = (int)(input - Math.Pow(minSq, 2));

            Console.WriteLine($"{minSq}, {diff}");

            var point = (x: minSq, y: minSq);

            var n = diff / minSq;
            var extra = diff % minSq;

            Console.WriteLine($"n={n}");

            switch (n)
            {
                case 0:
                    point.x += diff == 0 ? 0 : 1;
                    point.y -= extra;
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

            var half = minSq / 2;

            var dist = Math.Abs((point.x - half) + (half - point.y)) - 1;

            Console.WriteLine(point);
            Console.WriteLine($"half={half}, dist={dist}");

        }

        private void Solve2(bool test)
        {
            var n = 9;
            var grid = new int[n, n];

            var current = (x: n / 2, y: n / 2);
 
            int dx = 1;
            int dy = 0;

            grid[current.y, current.x] = 1;
            current.x++;

            while (current.x != n && current.y != n)
            {
                grid[current.y, current.x] = GetCellValue(grid, n, current.x, current.y);

                if (grid[current.y, current.x] > 361527)
                {

                    Console.WriteLine($"Smallest value larger than n = {grid[current.y, current.x]}");
                    break;
                }

                if (dx == 1)
                {
                    // try moving up
                    if (grid[current.y - 1, current.x] == 0)
                    {
                        dx = 0;
                        dy = -1;
                    }
                }
                else if (dy == -1)
                {
                    // try moving left
                    if (grid[current.y, current.x - 1] == 0)
                    {
                        dy = 0;
                        dx = -1;
                    }
                }
                else if (dx == -1)
                {
                    //  try moving down
                    if (grid[current.y + 1, current.x] == 0)
                    {
                        dy = 1;
                        dx = 0;
                    }
                }
                else if (dy == 1)
                {
                    // try moving right
                    if (grid[current.y, current.x + 1] == 0)
                    {
                        dx = 1;
                        dy = 0;
                    }
                }
  
                current.x += dx;
                current.y += dy;

            }
        }

        private void Print(int[,] grid, int size)
        {
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($" {grid[i, j],9}");
                }
                Console.WriteLine();
            }
        }

        private int GetCellValue(int[,] grid, int size, int x, int y)
        {
            var n = 0;
            var points = new List<(int x, int y)>(8)
            {
                (x + 1, y),
                (x + 1, y - 1),
                (x, y - 1),
                (x - 1, y - 1),
                (x - 1, y),
                (x - 1, y + 1),
                (x, y + 1),
                (x + 1, y + 1)
            };

            foreach (var p in points)
            {
                if (p.x >= 0 && p.x < size && p.y >= 0 && p.y < size)
                {
                    n += grid[p.y, p.x];
                }
            }

            return n == 0 ? 1 : n;
        }
    }
}
