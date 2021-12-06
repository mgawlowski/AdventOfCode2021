using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day3 : AdventBase
    {
        public Day3() : base("3958484", "1613181")
        { }

        public override void RunPart1()
        {
            var binariesList = inputLines.ToList();

            var gammaRateBinary = CalculateGammaRate(binariesList);
            var epsilonRateBinary = CalculateEpsilonRate(gammaRateBinary);

            var result = BinaryToDecimal(gammaRateBinary) * BinaryToDecimal(epsilonRateBinary);

            PrintPart1Result(result);
        }

        private string CalculateGammaRate(List<string> binariesList)
        {
            string gammaRate = "";

            for (int i = 0; i < binariesList[0].Length; i++)
            {
                var bit = FindDominatingBit(binariesList, i, 1);

                gammaRate += bit;
            }

            return gammaRate;
        }

        private string CalculateEpsilonRate(string gammaRate)
        {
            string epsilonRate = "";

            foreach (var bit in gammaRate)
            {
                epsilonRate += FlipBit(bit);
            }

            return epsilonRate;
        }

        public override void RunPart2()
        {
            var binariesList = inputLines.ToList();

            var oxygenGeneratorRating = CalculateOxygenGeneratorRating(binariesList);
            var co2ScrubberRating = CalculateCO2ScrubberRating(binariesList);

            var result = oxygenGeneratorRating * co2ScrubberRating;

            PrintPart2Result(result);
        }

        private int CalculateOxygenGeneratorRating(List<string> binariesList)
        {
            for (int i = 0; i < binariesList[0].Length; i++)
            {
                var bit = FindDominatingBit(binariesList, i, 1);

                FilterBinaries(ref binariesList, i, bit);

                if (binariesList.Count() <= 1)
                    break;
            }

            return BinaryToDecimal(binariesList.Single());
        }

        private int CalculateCO2ScrubberRating(List<string> binariesList)
        {
            for (int i = 0; i < binariesList[0].Length; i++)
            {
                var bit = FindDominatingBit(binariesList, i, 1);

                //change to recessive bit
                bit = FlipBit(bit);

                FilterBinaries(ref binariesList, i, bit);

                if (binariesList.Count() <= 1)
                    break;
            }

            return BinaryToDecimal(binariesList.Single());
        }

        private int FindDominatingBit(List<string> binariesList, int index, int defaultWhenTie)
        {
            int ones = 0, zeroes = 0;

            foreach (var binary in binariesList)
            {
                _ = binary[index] == '1' ? ones++ : zeroes++;
            }

            return ones > zeroes ? 1 : (ones < zeroes ? 0 : defaultWhenTie);
        }

        private void FilterBinaries(ref List<string> binariesList, int index, int digit)
        {
            var filteredBinaries = new List<string>();

            foreach (var binary in binariesList)
            {
                if (binary[index] == char.Parse(digit.ToString()))
                    filteredBinaries.Add(binary);
            }

            binariesList = filteredBinaries;
        }

        private int BinaryToDecimal(string binary) => Convert.ToInt32(binary, 2);

        private int FlipBit(int bit)
        {
            if (bit != 0 && bit != 1)
                throw new ArgumentOutOfRangeException(nameof(bit), $"Valid values are '0' and '1'. Got {bit}");

            return bit == 1 ? 0 : 1;
        }

        private char FlipBit(char bit) => FlipBit(int.Parse(bit.ToString())).ToString().ElementAt(0);
    }
}
