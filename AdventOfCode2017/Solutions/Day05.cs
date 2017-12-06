using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Solutions
{
    public class Day05 : IDaySolution
    {
        public Day05() { }

        public void Solve(bool test = false)
        {
            Solve1(test);
            Solve2(test);
        }

        private void Solve1(bool test)
        {
            var file = test ? "Day05.1-test.txt" : "Day05.1.txt";
            var jumps = File
                .ReadLines($"input/{file}")
                .Select(j => Convert.ToInt32(j))
                .ToArray();

            var next = 0;
            var count = 0;
            while (next >= 0 && next < jumps.Length)
            {
                next = next + jumps[next]++;
                count++;
            }
            Console.WriteLine($"Number of moves (1): {count}"); 
        }

        private void Solve2(bool test)
        {
            var file = test ? "Day05.1-test.txt" : "Day05.1.txt";
            var jumps = File
                .ReadLines($"input/{file}")
                .Select(j => Convert.ToInt32(j))
                .ToArray();

            var next = 0;
            var count = 0;
            while (next >= 0 && next < jumps.Length)
            {
                var add = jumps[next] >= 3 ? -1 : 1;
                var index = next;
                next = next + jumps[next];
                jumps[index] += add;
                count++;
            }
            Console.WriteLine($"Number of moves (2): {count}"); 
        }
    }
}
