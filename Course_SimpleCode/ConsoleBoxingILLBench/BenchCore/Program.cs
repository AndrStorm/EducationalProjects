using System;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

namespace BenchCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<BoxingBenchmark>(); 
            BenchmarkRunner.Run<UnboxingTest>();
        }
    }


//|  Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
//|-------- |----------:|----------:|----------:|-------:|----------:|
//| TestBox | 2.0660 ns | 0.0681 ns | 0.0954 ns | 0.0038 |      24 B |
//|    Test | 0.0088 ns | 0.0106 ns | 0.0100 ns |      - |         - |
    [MemoryDiagnoser]
   // [RankColumn]
    public class UnboxingTest
    {

        [Benchmark]
        public void TestBox()
        {
            int res = 0;
            object a = 1;  //Boxing!
            res += (int)a;  //Unboxing!
        }

        [Benchmark]
        public void Test()
        {
            int res = 0;
            int a = 1;  
            res += a;  
        }

    }
}
