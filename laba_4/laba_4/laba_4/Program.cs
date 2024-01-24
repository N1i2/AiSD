using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SIZE = 6;

            int inf = int.MaxValue;
            int[,] douts =
            {
            //     1      2       3       4       5       6
            /*1*/ { 0,    28,     21,     59,     12,     27  },
            /*2*/ { 7,    0,      24,     inf,    21,     9   },
            /*3*/ { 9,    32,     0,      13,     11,     inf },
            /*4*/ { 8,    inf,    5,      0,      16,     inf },
            /*5*/ { 14,   13,     15,     10,     0,      22  },
            /*6*/ { 15,   18,     inf,    inf,    6,      0   }
            };
            
            int[,] koordDouts = new int[SIZE, SIZE];

            for (int x = 0; x < SIZE; x++)
            {
                for (int y = 0; y < SIZE; y++)
                {
                    if (x == y)
                        koordDouts[x, y] = 0;
                    else
                        koordDouts[x, y] = y+1;
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < SIZE; i++)
            {
                for (int x = 0; x < SIZE; x++)
                {
                    if (x == i || douts[x, i]==inf)
                        continue;

                    for(int y = 0; y < SIZE; y++)
                    {
                        if (y == i || x == y|| douts[i, y] == inf)
                            continue;

                        if (douts[x, y] > (douts[x, i] + douts[i, y]))
                        {
                            douts[x, y] = (douts[x, i] + douts[i, y]);
                            koordDouts[x, y] = i + 1;
                        }
                    }
                }
            }

            showInfo(douts, SIZE);
            Console.WriteLine("\n\n");
            showInfo(koordDouts, SIZE);
        }

        static void showInfo(int[,] Arr, int SIZE)
        {
            for (int x = 0; x < SIZE; x++)
            {
                for (int y = 0; y < SIZE; y++)
                    Console.Write($"{Arr[x, y]}\t");

                Console.WriteLine('\n');
            }
        }
    }
}
