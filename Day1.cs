using System;

namespace AdventOfCode2021
{
    public class Day1 : AdventBase
    {
        public override void RunPart1()
        {
            int? previous = null;
            int valueIncreasedCount = 0;

            foreach (var line in lines)
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

            Console.WriteLine(valueIncreasedCount);
        }

        public override void RunPart2()
        {
            int valueIncreasedCount = 0;

            for (int i = 0; i < lines.Length - 3; i++)
            {
                var current = SumThreeLinesValues(lines, i);
                var next = SumThreeLinesValues(lines, i + 1);

                if (next > current)
                {
                    valueIncreasedCount++;
                }
            }

            Console.WriteLine(valueIncreasedCount);
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
