using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleAsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello");
            GetCurrentDateTime();
            //GetCurrentDateTimeAsync();
            //GetCurrentDateTimeAsync().Wait();
            string msg = await GetCurrentDateTime2Async();
            Console.WriteLine(msg);

            do
            {
                Console.WriteLine("enter number");
                string num = Console.ReadLine();
                Console.WriteLine($"You enter: {num}");
            } while (true);

        }
        static void GetCurrentDateTime()
        {
                Thread.Sleep(2000);
                Console.WriteLine("time now");
                Console.WriteLine(DateTime.Now);
                Console.WriteLine($"thread id {Thread.CurrentThread.ManagedThreadId}");
        }


            static async Task GetCurrentDateTimeAsync()
        {
            while (true)
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(5000);
                    Console.WriteLine("return async void date time");
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine($"thread id {Thread.CurrentThread.ManagedThreadId}");
                });
            }
            
        }

        static async Task<string> GetCurrentDateTime2Async()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("return async string date time");
                Console.WriteLine($"thread id {Thread.CurrentThread.ManagedThreadId}");
                return DateTime.Now.ToString();
                
            });
            
        }
    }
}
