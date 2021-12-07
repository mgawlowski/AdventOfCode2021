using System;

namespace AdventOfCode2021
{
    public class Day2 : DayBase
    {
        public override string RunPart1()
        {
            int horizontal = 0;
            int depth = 0;

            foreach (var line in InputLines)
            {
                var input = line.Split(' ');
                var direction = input[0];
                var value = int.Parse(input[1]);

                switch (direction)
                {
                    case "forward":
                        horizontal += value;
                        break;

                    case "down":
                        depth += value;
                        break;

                    case "up":
                        depth -= value;
                        break;

                    default:
                        throw new Exception($"Unexpected input ({nameof(direction)} = {direction})");
                }
            }

            var result = horizontal * depth;

            return result.ToString();
        }

        public override string RunPart2()
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (var line in InputLines)
            {
                var input = line.Split(' ');
                var direction = input[0];
                var value = int.Parse(input[1]);

                switch (direction)
                {
                    case "forward":
                        horizontal += value;
                        depth += aim * value;
                        break;

                    case "down":
                        aim += value;
                        break;

                    case "up":
                        aim -= value;
                        break;

                    default:
                        throw new Exception($"Unexpected input ({nameof(direction)} = {direction})");
                }
            }

            var result = horizontal * depth;

            return result.ToString();
        }
    }
}
