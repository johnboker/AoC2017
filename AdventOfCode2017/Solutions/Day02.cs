using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Solutions
{
    public class Day02 : IDaySolution
    {
        public Day02() { }

        public void Solve(bool test = false)
        {
            Solve1(test);
            Solve2(test);
        }

        private void Solve1(bool test)
        {
            var file = test ? "Day02.1-test.txt" : "Day02.1.txt";
            var rows = File.ReadAllLines($"input/{file}")
                           .Select(a => a.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(b => Convert.ToInt32(b)));

            var n = rows.Sum(r => r.Max() - r.Min());
            Console.WriteLine(n);
        }

        private void Solve2(bool test)
        {
            var file = test ? "Day02.2-test.txt" : "Day02.1.txt";
            var rows = File.ReadAllLines($"input/{file}")
                           .Select(a => a.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(b => Convert.ToInt32(b)));
            
            var n = rows.Sum(r => FindPairValue(r.ToArray()));
            Console.WriteLine(n);
        }

        private int FindPairValue(int[] row)
        {
            for (var i = 0; i < row.Count(); i++)
            {
                for (int j = 0; j < row.Count(); j++)
                {
                    if (row[i] != row[j] && row[i] % row[j] == 0) {
                        //Console.WriteLine($"{row[i]}/{row[j]}={row[i] / row[j]}");
                        return row[i] / row[j];   
                    }
                }
            }

            return 0;
        }
    }
}
