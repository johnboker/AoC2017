using System;
using System.IO;

namespace AdventOfCode2017.Solutions
{
    public class Day01 : IDaySolution
    {
        public Day01() { }

        public void Solve(bool test = false)
        {
            Solve1(test);
            Solve2(test);
        }

        private void Solve1(bool test)
        {
            var file = test ? "Day01.1-test.txt" : "Day01.1.txt";
            var captchas = File.ReadAllLines($"input/{file}");
            foreach (var captcha in captchas)
            {
                Console.WriteLine($"Day 1.1 = {SolveCaptcha(captcha, 1)}");
            }
        }

        private void Solve2(bool test)
        {
            var file = test ? "Day01.2-test.txt" : "Day01.1.txt";
            var captchas = File.ReadAllLines($"input/{file}");
            foreach (var captcha in captchas)
            {
                Console.WriteLine($"Day 1.2 = {SolveCaptcha(captcha, captcha.Length / 2)}");
            }
        }

        private int SolveCaptcha(string captcha, int offset)
        {
            int sum = 0;

            for (var i = 0; i < captcha.Length; i++)
            {
                int n1 = captcha[i] - '0';
                int n2 = captcha[(i + offset) % captcha.Length] - '0';
                if (n1 == n2) sum += n1;
            }

            return sum;
        }
    }
}
