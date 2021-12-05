using System;
using System.IO;

namespace AdventOfCode2021
{
    public abstract class AdventBase
    {
        protected string[] lines;

        public AdventBase()
        {
            var filename = $@"../../../inputs/{GetType().Name.ToLower()}.txt";
            lines = File.ReadAllLines(filename);
        }

        public abstract void RunPart1();

        public abstract void RunPart2();
    }
}
