using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using MyDout;

namespace laba_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start;
            char chStart;
            Dout[] douts = new Dout[9];

            douts[0] = new Dout(0, 'A', (1, 7), (2, 10));
            douts[1] = new Dout(1, 'B', (0, 7), (5, 9), (6, 27));
            douts[2] = new Dout(2, 'C', (5, 8), (0, 10), (4, 31));
            douts[3] = new Dout(3, 'D', (7, 17), (8, 21), (4, 32));
            douts[4] = new Dout(4, 'E', (2, 31), (3, 32));
            douts[5] = new Dout(5, 'F', (2, 8), (1, 9), (7, 11));
            douts[6] = new Dout(6, 'G', (8, 15), (1, 27));
            douts[7] = new Dout(7, 'H', (5, 11), (8, 15), (3, 17));
            douts[8] = new Dout(8, 'I', (6, 15), (7, 15), (3, 21));

            chStart = Console.ReadKey().KeyChar;

            if ((int)chStart >= 97 && (int)chStart <= 105)
                start = (int)chStart - 97;
            else if ((int)chStart >= 65 && (int)chStart <= 73)
                start = (int)chStart - 65;
            else
                start = 0;

           int[] path = new int[9];

            for (int i = 0; i < path.Length; i++)
            {
                if (i == start)
                {
                    path[i] = 0;
                    continue;
                }
                path[i] = int.MaxValue;
            }

            path = Dekstr(start, douts, path);

            Console.WriteLine("\n\n");

            for (int i = 0; i < path.Length; i++)
            {
                Console.WriteLine("Кротчайший путь до {0} = {1};", douts[i].doutSimbl, path[i]);
            }
        }

        public static int[] Dekstr(int start, Dout[] graph, int[] path)
        {

            Queue<Dout> queue = new Queue<Dout>();
            queue.Enqueue(graph[start]);

            while (queue.Count > 0)
            {
                start = queue.Peek().id;

                for (int i = 0; i < queue.Peek().size; i++)
                {
                    if (path[start] + queue.Peek().GetLeth(i) < path[graph[queue.Peek().GetRabr(i)].id])
                    {
                        path[graph[queue.Peek().GetRabr(i)].id] = path[start] + queue.Peek().GetLeth(i);
                        queue.Enqueue(graph[queue.Peek().GetRabr(i)]);
                    }
                }

                queue.Dequeue();
            }

            return path;
        }

        public static bool CheckNeed(Dout dout, char[] check, int size)
        {
            for (int i = 0; i < size; i++)
                if (dout.doutSimbl == check[i])
                    return false;

            return true;
        }
    }
}