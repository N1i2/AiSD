using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using MyGraf;

namespace laba2
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            GrafD[] uzels = new GrafD[10];

            uzels[0] = new GrafD(2, 2, 5);
            uzels[1] = new GrafD(3, 1, 7, 8);
            uzels[2] = new GrafD(1, 8);
            uzels[3] = new GrafD(2, 6, 9);
            uzels[4] = new GrafD(2, 1, 6);
            uzels[5] = new GrafD(3, 4, 5, 9);
            uzels[6] = new GrafD(2, 2, 8);
            uzels[7] = new GrafD(3, 2, 3, 7);
            uzels[8] = new GrafD(3, 4, 6, 10);
            uzels[9] = new GrafD(1, 9);

            Console.Write("Введите стартовый символ для поиска в ширину:");
            if (!int.TryParse(Console.ReadLine(), out int start) || start < 1 || start > 10)
                start = 1;
            LocateGraph(uzels, start);

            Console.Write("\n\nВведите стартовый символ для поиска в глубину:");
            if (!int.TryParse(Console.ReadLine(), out start) || start < 1 || start > 10)
                start = 1;
            LocateGraph(uzels, start, 1);

            Console.WriteLine("\n\nВывод спска ребер:");
            for (int i = 0, schet = 1; i < uzels.Length; i++)
            {
                for (int j = 0; j < uzels[i].Dout.Length; j++, schet++)
                {
                    Console.WriteLine("{0}) ребро от {1} в {2}", schet, i + 1, uzels[i].Dout[j]);
                }
            }

            Console.WriteLine("\n\nВывод матрицы смежности:");
            int[,] grafsMatr = new int[uzels.Length, uzels.Length];
            for (int i = 0; i < uzels.Length; i++)
                for (int j = 0; j < uzels[i].Dout.Length; j++)
                    grafsMatr[i, (uzels[i].Dout[j] - 1)] = 1;

            Console.Write("0 ||");
            for (int i = 1; i <= uzels.Length; i++)
                Console.Write($"{i} ");
            Console.WriteLine("\n".PadRight(24, '='));

            for (int i = 0; i < uzels.Length; i++)
            {
                if(i<9)
                Console.Write($"{i+1} ||");
                else
                    Console.Write($"{i + 1}||");
                for (int j = 0; j < uzels.Length; j++)
                    Console.Write($"{grafsMatr[i, j]} ");
                Console.WriteLine();
            }

            Console.WriteLine("\n\nВывод списка смежности:");

            for (int i = 0; i < uzels.Length; i++)
            {
                Console.Write("Для узла {0}: |", i+1);
                for (int j = 0; j < uzels[i].Dout.Length;j++)
                    Console.Write($" {uzels[i].Dout[j]} |");
                Console.WriteLine();
            }
        }

        static void LocateGraph(GrafD[] uzels, int startNumber, int how = 0)
        {
            int[] checkUzel = new int[uzels.Length];
            int index = 0;

            if (how == 0)
            {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(startNumber);

                while (queue.Count() > 0)
                {
                    for (int i = 0; i < uzels[queue.Peek() - 1].Dout.Length; i++)
                    {
                        if (CheckUzel(ref index, checkUzel, uzels[queue.Peek() - 1].Dout[i]))
                            queue.Enqueue(uzels[queue.Peek() - 1].Dout[i]);
                    }

                    if (CheckUzel(ref index, checkUzel, queue.Peek()))
                        Console.Write("");
                    Console.WriteLine("Проход по узлу {0}", queue.Dequeue());
                }
            }
            else
            {
                Stack<int> stack = new Stack<int>();
                stack.Push(startNumber);

                while (stack.Count() > 0)
                {
                    int useUzel = stack.Pop();

                    for (int i = (uzels[useUzel - 1].Dout.Length - 1); i >= 0; i--)
                    {
                        if (CheckUzel(ref index, checkUzel, uzels[useUzel - 1].Dout[i]))
                            stack.Push(uzels[useUzel - 1].Dout[i]);
                    }

                    if (CheckUzel(ref index, checkUzel, useUzel))
                        Console.Write("");
                    Console.WriteLine("Проход по узлу {0}", useUzel);
                }
            }

            bool CheckUzel(ref int _index, int[] check, int uzel)
            {
                bool individual = true;

                for (int i = 0; i < _index; i++)
                {
                    if (check[i] == uzel)
                    {
                        individual = false;
                        break;
                    }
                }

                if (individual)
                    PushCheck(ref _index, check, uzel);

                return individual;
            }

            void PushCheck(ref int _index, int[] check, int uzel)
            {
                check[_index] = uzel;
                _index++;
            }
        }
    }
}
