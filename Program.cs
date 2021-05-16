using System;

namespace AlphaListParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
        }
    }
}
