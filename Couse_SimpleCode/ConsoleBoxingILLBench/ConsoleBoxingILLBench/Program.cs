using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleBoxingILLBench
{
    public interface IPrintable
    {
        void Print();
    }
    public struct Point : IPrintable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Print()
        {
            Console.WriteLine($"X:{X}\tY:{Y}");
        }
    }
    public class ClassPoint : IPrintable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Print()
        {
            Console.WriteLine($"X:{X}\tY:{Y}");
        }
    }
    public class Program1
    {
        static void Main(string[] args)
        {
            int a = 1;
            object b = a;  //Boxing!
            int c = (int)b;  //Unboxing!

            c.GetType();  //Boxing! because of method of object and structure

            Point myPoint = new Point {X=2,Y=3};
            Print(myPoint); //Boxing! because of Interface and structure

            ClassPoint classPoint = new ClassPoint { X = 1, Y = 4 };
            Print(classPoint);

            Console.ReadLine();
        }

        public static void Print(IPrintable printable)
        {
            printable.Print();
        }

    }
}
