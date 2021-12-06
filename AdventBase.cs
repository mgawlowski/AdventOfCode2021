using System;
using System.IO;

namespace AdventOfCode2021
{
    public abstract class AdventBase
    {
        protected readonly string[] inputLines;
        protected readonly string part1Solution;
        protected readonly string part2Solution;

        public AdventBase()
        {
            var filename = $@"../../../inputs/{GetType().Name.ToLower()}.txt";
            inputLines = File.ReadAllLines(filename);
        }
        public AdventBase(string part1Solution) : this()
        {
            this.part1Solution = part1Solution;
        }

        public AdventBase(string part1Solution, string part2Solution) : this(part1Solution)
        {
            this.part2Solution = part2Solution;
        }

        public abstract void RunPart1();

        public abstract void RunPart2();

        public void PrintPart1Result(object result) => PrintResultAndSolution(result.ToString(), part1Solution);

        public void PrintPart2Result(object result) => PrintResultAndSolution(result.ToString(), part2Solution);

        private void PrintResultAndSolution(string result, string solution)
        {
            Console.Write(result);

            if (!String.IsNullOrWhiteSpace(solution))
            {
                if (result.Equals(solution))
                    Console.Write($" (CORRECT)");
                else
                    Console.Write($" (FALSE, solution = {solution})");
            }

            Console.WriteLine();
        }
    }
}
