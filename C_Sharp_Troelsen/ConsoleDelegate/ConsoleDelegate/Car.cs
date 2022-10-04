using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDelegate
{
    class Car
    {
        // Данные состояния,
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        // Исправен ли автомобиль?
        private bool carlsDead;
        // Конструкторы класса,
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }




        public event CarEngineHandler Exploded;




        // 1. Определить тип делегата.
        public delegate void CarEngineHandler(string msgForCaller);
        //2. Определить переменную-член этого типа делегата.
        private CarEngineHandler listOfHandlers;
        // 3. Добавить регистрационную функцию для вызывающего кода.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }


        // 4. Реализовать метод Accelerate () для обращения к списку
        // вызовов делегата в подходящих обстоятельствах.
        public void Accelerate(int delta)
        {
            // Если этот автомобиль сломан, то отправить сообщение об этом,
            if (carlsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Sorry, this car is dead...");

                Exploded?.Invoke("Event Trigger Explode");
                //listOfHandlers.Invoke("dsfgds");
            }
            else
            {
                CurrentSpeed += delta;
                // Автомобиль почти сломан?
                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                    carlsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }

        }
    }
}
