using System;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutions = GetSolutions();
            foreach (var solution in solutions)
            {
                var puzzle = (IDaySolution)(Activator.CreateInstance(solution));
                Console.WriteLine($"*************** {solution.Name} ***************");
                puzzle.Solve(false);
            }
        }

        public static IOrderedEnumerable<Type> GetSolutions()
        {
            var type = typeof(IDaySolution);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass)
                .OrderBy(a => a.Name);
            return types;
        }
    }
}
