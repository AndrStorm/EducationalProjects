using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace ConsoleAsyncDelegat
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        private static bool isDone = false;

        static void Main(string[] args)
        {
            Console.WriteLine("***** AsyncCallbackDelegate Example *****");
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 10,
            new AsyncCallback(AddComplete), "Thanks for this numbers to main()");
            // Предположим, что здесь делается какая-то другая работа...
            while (!isDone)
            {
                Console.WriteLine("Working....");
                Thread.Sleep(1000);
            }
            Console.ReadLine();

        }

        static int Add (int x, int y)
        {
            Console.WriteLine($"Add invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            return x + y;
        }

        static void AddComplete(IAsyncResult iar)
        {
            Console.WriteLine($"Add invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Your addition is complete");
            isDone = true;

            AsyncResult ar = (AsyncResult)iar;
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}.", b.EndInvoke(iar));
            isDone = true;

            string msg = (string)iar.AsyncState;
            Console.WriteLine(msg);
        }
    }
}
