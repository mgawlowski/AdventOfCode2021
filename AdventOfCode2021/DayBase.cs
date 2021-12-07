using System;
using System.IO;

namespace AdventOfCode2021
{
    public abstract class DayBase
    {
        protected readonly string[] InputLines;

        public DayBase()
        {
            var filename = $@"../../../../AdventOfCode2021/inputs/{GetType().Name.ToLower()}.txt";
            InputLines = File.ReadAllLines(filename);
        }

        public abstract string RunPart1();

        public abstract string RunPart2();
    }
}
