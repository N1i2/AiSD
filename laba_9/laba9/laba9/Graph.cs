using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraph
{
    [Serializable]
    public class Graph
    {
        public Graph()
        {

        }

        [Serializable]
        public class Uzel
        {
            public Uzel(int[] longPath)
            {
                path = longPath;
            }

            public int[] path { get; private set; }
        }

        public Graph(int size)
        {
            dout = new Uzel[size];
            CreatGraph(size);
        }

        public Uzel[] dout { get;private set; }

        private void CreatGraph(int size)
        {
            int[] pathes;
            for (int i = 0; i < dout.Length; i++)
            {
                pathes = new int[size];
                for (int j = 0, path; j < size; j++)
                {
                    if (i == j)
                        continue;

                    Console.Write($"Введите длинну пути от города {i + 1} до города {j + 1}:\t");

                    if (!int.TryParse(Console.ReadLine(), out path) || path < 1)
                    {
                        Console.WriteLine("Такого не может быть");
                        j--;
                        continue;
                    }

                    pathes[j] = path;
                }

                dout[i] = new Uzel(pathes);
            }
        }
    }
}