using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tower;
            int disk;

            while (true)
            {
                Console.Write("Введите количество колышков:");
                if (!int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out tower))
                {
                    Console.WriteLine("\nПроизошла ошибка");
                    continue;
                }

                Console.Write("\nВведите количество дисков:");
                if (!int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out disk))
                {
                    Console.WriteLine("\nПроизошла ошибка");
                    continue;
                }

                Console.WriteLine("\nВсe верно\n");
                break;
            }

            Console.ReadKey();
            Console.Clear();

            SchetTower(disk, 1, 2, tower);
        }

        static void SchetTower(int end, int strt, int use,int help)
        {
            if (end == 1)
            {
                Console.WriteLine($"Переместить диск {end} c {strt} на {help}");
                return;
            }

            SchetTower(end - 1, strt, help, use);
            Console.WriteLine($"Переместить диск {end} c {strt} на {help}");
            SchetTower(end - 1, use, strt, help);
        }
    }
}