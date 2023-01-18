using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("birth year");
            int year =Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" your old : " + (2022 - year));
        }
    }
}
