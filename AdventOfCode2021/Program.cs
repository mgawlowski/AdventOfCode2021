using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            DayBase puzzle = new Day5();

            Console.WriteLine(puzzle.RunPart1());
            Console.WriteLine(puzzle.RunPart2());
        }
    }
}
