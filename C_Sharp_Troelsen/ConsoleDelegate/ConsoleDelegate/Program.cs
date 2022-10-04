using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");
            // Создать объект Car.
            Car cl = new Car("SlugBug", 100, 10);
            // Сообщить объекту Car, какой метод вызывать,
            // когда он пожелает отправить сообщение.
            cl.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            cl.RegisterWithCarEngine(OnCarEngineEvent2);
            //cl.Exploded += MyCarExploded; //I event
            //cl.Exploded += (string msg) => { Console.WriteLine(msg); }; //II event => anonim
            cl.Exploded += (string msg) => Console.WriteLine(msg); //III shotrest variant

            // Увеличить скорость (это инициирует события).
            Console.WriteLine("***** Speeding пр *****");
            for (int i = 0; i < 6; i++ )
                cl.Accelerate(20);
            Console.ReadLine();
        }

        private static void MyCarExploded(string msgForCaller)
        {
            Console.WriteLine("=> {0}", msgForCaller);
        }

        // Цель для входящих сообщении.
        static void OnCarEngineEvent(string msg)
        { 
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine( "=> {0}", msg);
            Console.WriteLine("*********************************\n") ;
        }

        static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n");
        }
    }




}
