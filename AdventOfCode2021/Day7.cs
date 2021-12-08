using System;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day7 : DayBase
    {
        public override string RunPart1() => RunPart1(null);
        public override string RunPart2() => RunPart2(null);

        public string RunPart1(string input)
        {
            var crabsList = (input ?? InputLines[0]).Split(',').Select(_ => int.Parse(_)).ToList();

            int leastFuel = int.MaxValue;

            for (var chosenPosition = crabsList.Min(); chosenPosition <= crabsList.Max(); chosenPosition++)
            {
                int fuel = 0;
                foreach (var crabPosition in crabsList)
                {
                    fuel += Math.Abs(crabPosition - chosenPosition);
                }
                if (fuel < leastFuel)
                    leastFuel = fuel;
            }

            return leastFuel.ToString();
        }

        public string RunPart2(string input)
        {
            var crabsList = (input ?? InputLines[0]).Split(',').Select(_ => int.Parse(_)).ToList();

            int leastFuel = int.MaxValue;

            for (var chosenPosition = crabsList.Min(); chosenPosition <= crabsList.Max(); chosenPosition++)
            {
                int fuel = 0;
                foreach (var crabPosition in crabsList)
                {
                    fuel += CalculateFuel(crabPosition, chosenPosition);
                }
                if (fuel < leastFuel)
                    leastFuel = fuel;
            }

            return leastFuel.ToString();
        }

        private int CalculateFuel(int positionA, int positionB)
        {
            var difference = Math.Abs(positionA - positionB);

            int result = 0;
            for (int i = 1; i <= difference; i++)
            {
                result += i;
            }

            return result;
        }
    }
}
