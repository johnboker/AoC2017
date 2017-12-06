using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Solutions
{
    public class Day06 : IDaySolution
    {
        public Day06() { }

        public void Solve(bool test = false)
        {
            var file = test ? "Day06.1-test.txt" : "Day06.1.txt";
            var banks = File
                .ReadAllText($"input/{file}")
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(j => Convert.ToInt32(j))
                .ToArray();

            List<string> bankMemory = new List<string> {
                SerializeBanks(banks)
            };

            var loopValue = "";
            while (true)
            {
                var n = banks.Max();
                var index = Array.IndexOf(banks, n);
                banks[index] = 0;
                index++;
                while (n > 0)
                {
                    banks[index++ % banks.Length]++;
                    n--;
                }

                var s = SerializeBanks(banks);
                if (bankMemory.Contains(s))
                {
                    loopValue = s;
                    break;
                }
                bankMemory.Add(s);
            }

            var idx = Array.IndexOf(bankMemory.ToArray(), loopValue);
            Console.WriteLine($"Until Loop: {bankMemory.Count()}");
            Console.WriteLine($"Loop Size: {bankMemory.Count() - idx}");
        }

        private void Solve1(bool test) { }

        private void Solve2(bool test) { }

        private string SerializeBanks(int[] banks)
        {
            return string.Join("-", banks.Select(a => a.ToString()));
        }
    }
}
