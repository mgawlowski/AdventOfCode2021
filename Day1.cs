using System;

namespace AdventOfCode2021
{
    public class Day1 : AdventBase
    {
        public Day1() : base("1559", "1600")
        { }

        public override void RunPart1()
        {
            int? previous = null;
            int valueIncreasedCount = 0;

            foreach (var line in inputLines)
            {
                var current = int.Parse(line);

                if (previous == null)
                {
                    previous = current;
                    continue;
                }

                if (current > previous)
                {
                    valueIncreasedCount++;
                }

                previous = current;
            }

            PrintPart1Result(valueIncreasedCount);
        }

        public override void RunPart2()
        {
            int valueIncreasedCount = 0;

            for (int i = 0; i < inputLines.Length - 3; i++)
            {
                var current = SumThreeLinesValues(inputLines, i);
                var next = SumThreeLinesValues(inputLines, i + 1);

                if (next > current)
                {
                    valueIncreasedCount++;
                }
            }

            PrintPart2Result(valueIncreasedCount);
        }

        private int SumThreeLinesValues(string[] lines, int startIndex)
        {
            int sum = 0;

            for(int i = 0; i < 3; i++)
            {
                sum += int.Parse(lines[startIndex + i]);
            }

            return sum;
        }
    }
}
