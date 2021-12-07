using System;

namespace AdventOfCode2021
{
    public class Day1 : DayBase
    {
        public override string RunPart1()
        {
            int? previous = null;
            int valueIncreasedCount = 0;

            foreach (var line in InputLines)
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

            return valueIncreasedCount.ToString();
        }

        public override string RunPart2()
        {
            int valueIncreasedCount = 0;

            for (int i = 0; i < InputLines.Length - 3; i++)
            {
                var current = SumThreeLinesValues(InputLines, i);
                var next = SumThreeLinesValues(InputLines, i + 1);

                if (next > current)
                {
                    valueIncreasedCount++;
                }
            }

            return valueIncreasedCount.ToString();
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
