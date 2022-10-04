using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBoxingILLBench;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchCore
{
    [MemoryDiagnoser]
    [RankColumn]
    public class BoxingBenchmark
    {
        Point myPoint = new Point { X = 2, Y = 3 };
        ClassPoint classPoint = new ClassPoint { X = 1, Y = 4 };

        [Benchmark]
        public void TestStructure()
        {
            Program1.Print(myPoint); //Boxing! because of Interface and structure
        }


        [Benchmark]
        public void TestClass()
        {
            Program1.Print(classPoint);
        }

    }
}
