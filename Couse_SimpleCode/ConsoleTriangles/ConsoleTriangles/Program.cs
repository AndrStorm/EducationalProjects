using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter heigh of triangles ");
            int height = Int32.Parse(Console.ReadLine());
            

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("#");
                }

                Console.WriteLine(" ");
            }



            Console.WriteLine(" ");



            for (int i = 0; i < height; i++)
            {
                for (int j = height; j > i; j--)
                {
                    Console.Write("#");
                }

                Console.WriteLine(" ");
            }


            Console.WriteLine(" ");


            for (int i = 0; i < height; i++)
            {

                for (int j = height-1; j > i; j--)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j <= i; j++)
                {
                    Console.Write("#");
                }

                Console.WriteLine(" ");
            }


            Console.WriteLine(" ");


            for (int i = 0; i < height; i++)
            {

                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = height; j > i; j--)
                {
                    Console.Write("#");
                }

                

                Console.WriteLine(" ");
            }





            Console.ReadLine();

        }
    }
}
