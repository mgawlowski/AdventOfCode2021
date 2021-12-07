using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day6 : DayBase
    {
        public override string RunPart1()
        {
            var fishList = InputLines[0].Split(',').Select(line => new Fish(int.Parse(line))).ToList();

            for(var days = 80; days > 0; days--)
            {
                var newbornsCount = 0;
                foreach(var fish in fishList)
                {
                    if (!fish.TryAge())
                        newbornsCount++;
                }

                AddFish(ref fishList, newbornsCount);
            }

            var result = fishList.Count().ToString();

            return result.ToString();
        }

        public override string RunPart2()
        {
            var fishList = InputLines[0].Split(',').Select(line => int.Parse(line)).ToList();

            long[] fishByAge = new long[9];

            for (int i = 0; i < fishByAge.Length; i++)
            {
                fishByAge[i] = fishList.Where(fish => fish == i).Count();
            }

            for (var days = 256; days > 0; days--)
            {
                var delta = fishByAge[0];

                for (int i = 0; i < fishByAge.Length - 1; i++)
                {
                    fishByAge[i] = fishByAge[i + 1];
                }

                fishByAge[6] += delta;
                fishByAge[8] = delta;
            }

            var result = fishByAge.ToList().Sum();

            return result.ToString();
        }

        private class Fish
        {
            private int Age { get; set; }

            public bool IsDead { get; set; }

            public Fish(int age) => Age = age;

            public bool TryAge()
            {
                if (Age > 0)
                {
                    Age--;
                    return true;
                }

                Age = 6;
                return false;
            }

            public override string ToString() => Age.ToString();
        }

        private void AddFish(ref List<Fish> fishList, int number)
        {
            for (int i = number; i > 0; i--)
            {
                fishList.Add(new Fish(8));
            }
        }
    }
}
