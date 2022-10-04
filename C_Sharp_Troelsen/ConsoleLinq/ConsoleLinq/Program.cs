using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int[] myArray2 = new int[] {5,6,7,8,9,21};



            var orderedArray = from i in myArray where (i > 2) orderby i ascending select i;

            foreach (var item in orderedArray)
                Console.Write($"\t{item}");

            Console.WriteLine();




            var unionArray = (from i in myArray select i).Union(from j in myArray2 select j);

            foreach (var item in unionArray)
                Console.Write($"\t{item}");

            Console.WriteLine();


            Console.ReadLine();

        }
    }
}
