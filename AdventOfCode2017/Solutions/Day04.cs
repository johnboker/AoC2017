using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Solutions
{
    public class Day04 : IDaySolution
    {
        public Day04() { }

        public void Solve(bool test = false)
        {
            Solve1(test);
            Solve2(test);
        }

        private void Solve1(bool test)
        {
            var file = test ? "Day04.1-test.txt" : "Day04.1.txt";
            var phrases = File.ReadLines($"input/{file}");

            int n = 0;
            foreach (var phrase in phrases)
            {
                n += IsValid1(phrase) ? 1 : 0;
            }

            Console.WriteLine($"Valid Passphrases (1): {n}");
        }

        private void Solve2(bool test)
        {
            var file = test ? "Day04.2-test.txt" : "Day04.1.txt";
            var phrases = File.ReadLines($"input/{file}");

            int n = 0;
            foreach (var phrase in phrases)
            {
                n += IsValid2(phrase) ? 1 : 0;
            }

            Console.WriteLine($"Valid Passphrases (2): {n}");
        }



        private bool IsValid1(string phrase)
        {
            var words = phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var counts = (from w in words
                          group w by w into g
                          select new { g.Key, Count = g.Count() }).ToList();

            var isValid = !counts.Any(a => a.Count > 1);
            return isValid;
        }

        private bool IsValid2(string phrase)
        {
            var words = phrase
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(a => String.Concat(a.OrderBy(c => c)));
            
            var counts = (from w in words
                          group w by w into g
                          select new { g.Key, Count = g.Count() }).ToList();

            var isValid = !counts.Any(a => a.Count > 1);
            return isValid;
        }
    }
}
