using System;
using MyMetod;

//5 10 6 12 3 24 7 8
//1 5 3 7 1 4 10 15
//3 8 10 12 1 6 2 4 8

namespace laba7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr =HelpStaticMetod.FullArray();
            int[] helpArr=HelpStaticMetod.LocateLendth(arr);

            HelpStaticMetod.ShowAllInfo(arr, helpArr);

            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}