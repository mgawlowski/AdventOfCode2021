using System;

namespace AdventOfCode2021
{
    public class Day3 : AdventBase
    {
        public override void RunPart1()
        {
            var gammaRateBinary = CalculateGammaRate();
            var epsilonRateBinary = CalculateEpsilonRate(gammaRateBinary);

            var result = BinaryToDecimal(gammaRateBinary) * BinaryToDecimal(epsilonRateBinary);

            Console.WriteLine(result);
        }

        private int BinaryToDecimal(string binary) => Convert.ToInt32(binary, 2);

        private string CalculateGammaRate()
        {
            var digitScore = new int[inputLines[0].Length];

            foreach (var line in inputLines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    var score = line[i] == '1' ? 1 : -1;
                    digitScore[i] += score;
                }
            }

            var result = new int[digitScore.Length];

            // > 0 - more '1'
            // = 0 - tie
            // < 0 - more '0'
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = digitScore[i] > 0 ? 1 : 0;
            }

            var binary = DigitsToString(result);

            return binary;
        }

        private string CalculateEpsilonRate(string gammaRate)
        {
            string epsilonRate = "";

            foreach (var digit in gammaRate)
            {
                epsilonRate += digit == '1' ? 0 : 1;
            }

            return epsilonRate;
        }

        private string DigitsToString(int[] digits)
        {
            string result = "";

            foreach (var digit in digits)
            {
                result += digit;
            }

            return result;
        }

        public override void RunPart2()
        {

            Console.WriteLine();
        }
    }
}
