using AdventOfCode2021;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class SolutionTests
    {
        [Theory]
        [InlineData(1, 1, "1559")]
        [InlineData(1, 2, "1600")]
        [InlineData(2, 1, "1670340")]
        [InlineData(2, 2, "1954293920")]
        [InlineData(3, 1, "3958484")]
        [InlineData(3, 2, "1613181")]
        [InlineData(4, 1, "64084")]
        [InlineData(4, 2, "12833")]
        [InlineData(6, 1, "389726")]
        [InlineData(6, 2, "1743335992042")]
        public void Test(int day, int part, string solution)
        {
            Assert.Equal(solution, Run(day, part));
        }

        private string Run(int day, int part)
        {
            var dayClass = GetClass(day);

            if (part == 1)
                return dayClass.RunPart1();

            if (part == 2)
                return dayClass.RunPart2();

            return "";
        }

        private DayBase GetClass(int day) => (DayBase)Activator.CreateInstance(Type.GetType($"AdventOfCode2021.Day{day}, AdventOfCode2021, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"));

    }
}
