using System;
using System.Linq;

namespace MyMetod
{
    static class HelpStaticMetod
    {
        public static int[] FullArray()
        {
            int[] arr;

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите последовательность int через пробел\n(и только через пробел)");

                    arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                    return arr;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor= ConsoleColor.Red;

                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static int[] LocateLendth(int[] arr)
        {
            int helpSize = arr.Length;
            int[] helpArr = Enumerable.Repeat(1, helpSize).ToArray();

            for (int i = 1; i < helpSize; i++)
                for (int j = 0; j < i; j++)
                    if (arr[i] > arr[j] && helpArr[i] <= helpArr[j])
                        helpArr[i] = helpArr[j] + 1;

            return helpArr;
        }

        public static void ShowAllInfo(int[] arr, int[] helpArr)
        {
            int start = helpArr.Max();

            if (start == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nЦепочки как таковой нет");
                Console.WriteLine("Максимальная длинна 1");
                Console.WriteLine("Одна из них:");
                Console.WriteLine(arr[0]);
                return;
            }

            int[] vivodArr = new int[start];

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nСамая длинная строка: {0}", start);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nОдна из них:");

            for (int i = arr.Length - 1; start > 0; i--)
                if (helpArr[i] == start)
                    vivodArr[--start] = arr[i];


            Console.Write(vivodArr[0]);
            for (int i = 1; i < vivodArr.Length; i++)
                Console.Write($", {vivodArr[i]}");

            Console.WriteLine('\n');
        }
    }
}