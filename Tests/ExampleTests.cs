using AdventOfCode2021;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class ExampleTests
    {
        private readonly string Day7ExampleInput = "16,1,2,0,4,2,7,1,2,14";

        [Fact]
        public void Day7_Part1_Example_Test()
        {
            Assert.Equal("37", new Day7().RunPart1(Day7ExampleInput));
        }

        [Fact]
        public void Day7_Part2_Example_Test()
        {
            Assert.Equal("168", new Day7().RunPart2(Day7ExampleInput));
        }
    }
}
