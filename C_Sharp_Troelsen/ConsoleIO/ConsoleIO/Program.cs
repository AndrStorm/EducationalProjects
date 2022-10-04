using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tasks = new string[] {"task1","task2","task3" };
            File.WriteAllLines(@"task.txt", tasks);

            foreach (string task in File.ReadLines(@"task.txt"))
            {
                Console.WriteLine($"do it: {task}");
            }

            Console.ReadLine();
        }
    }
}
