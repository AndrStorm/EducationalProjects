using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRef
{
    
    class Program
    {

        static void ResizeArray <T> (ref T[] firstArray, int resizeValue)
        {
            T[] newArray = new T[resizeValue];

                for (int i = 0; i < firstArray.Length && i < newArray.Length; i++)
                newArray[i] = firstArray[i];

            firstArray = newArray;
        }

        static void AddFirstElement(ref int[] firstArray, int Value)
        {
            InsertByIndex(ref firstArray, Value, 0);
        }

        static void AddLastElement(ref int[] firstArray, int Value)
        {
            InsertByIndex(ref firstArray, Value, firstArray.Length);
        }

        static void InsertByIndex(ref int[] firstArray, int Value, int index)
        {
            int[] newArray = new int[firstArray.Length +1];

            for (int i = 0; i < index; i++)
                newArray[i] = firstArray[i];

            newArray[index] = Value;

            for (int i = index; i < firstArray.Length; i++)
                newArray[i+1] = firstArray[i];

            firstArray = newArray;
        }

        static void DeleteFirstElement(ref int[] firstArray)
        {
            int[] newArray = new int[firstArray.Length-1];

            for (int i = 0; i < firstArray.Length-1; i++)
                newArray[i] = firstArray[i+1];

            firstArray = newArray;
        }

        static void DeleteLastElement(ref int[] firstArray)
        {
            int[] newArray = new int[firstArray.Length - 1];

            for (int i = 0; i < firstArray.Length - 1; i++)
                newArray[i] = firstArray[i];

            firstArray = newArray;
        }

        static void DeleteByIndex(ref int[] firstArray, int index)
        {
            int[] newArray = new int[firstArray.Length - 1];

            for (int i = 0; i < index; i++)
                newArray[i] = firstArray[i];

            for (int i = index; i < firstArray.Length - 1; i++)
                newArray[i] = firstArray[i+1];

            firstArray = newArray;
        }

        static void Main(string[] args)
        {
            int[] myArray = new int[10]
                { 1,2,3,4,5,6,7,8,9,1};
            
            string[] myStringArray = { "asd", "wed", "few" };
            int menu = 0;

            Console.WriteLine("1-resize, 2-add element to start, 3 - add to last, 4 - insert by index, 5 - delete first, 6 - delete last, 7 delete by index");
            menu = Int32.Parse(Console.ReadLine());
            if (menu == 1)
            {
                Console.WriteLine("enter the size change value");
                int resizeValue = Int32.Parse(Console.ReadLine());

                ResizeArray(ref myArray, resizeValue);
                Console.WriteLine(myArray.Length);
            }
            else if (menu == 2)
            {
                Console.WriteLine("enter the element");
                int value = Int32.Parse(Console.ReadLine());
                AddFirstElement(ref myArray, value);

                Console.WriteLine("[0] = " + myArray[0]);
            }
            else if (menu == 3)
            {
                Console.WriteLine("enter the element");
                int value = Int32.Parse(Console.ReadLine());
                AddLastElement(ref myArray, value);

                Console.WriteLine("[" + (myArray.Length - 1) + "] = " + myArray[myArray.Length - 1]);
            }
            else if (menu == 4)
            {
                Console.WriteLine("enter the element");
                int value = Int32.Parse(Console.ReadLine());
                Console.WriteLine("enter the index from 0 to " + (myArray.Length));
                int index = Int32.Parse(Console.ReadLine());
                InsertByIndex(ref myArray, value,index);

                Console.WriteLine("[" + index + "] = " + myArray[index]);
            }
            else if(menu == 5)
            {
                DeleteFirstElement(ref myArray);

            }
            else if (menu == 6)
            {
                DeleteLastElement(ref myArray);

            }
            else
            {
                Console.WriteLine("enter the index from 0 to " + (myArray.Length - 1));
                int index = Int32.Parse(Console.ReadLine());
                DeleteByIndex(ref myArray, index);

            }



            for (int i = 0; i < myArray.Length; i++)
                Console.Write(myArray[i] + " ");

            Console.ReadLine();
        }
    }
}
