using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGenom;
using MyGraph;
using MyPath;

namespace laba_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int colUzel;
            Graph dout;

            Console.Write("Введите количество узлов\n(в случае некоректного ввода будет поставлно 5):\t");
            if (!int.TryParse(Console.ReadLine(), out colUzel) || colUzel < 5 || colUzel > 20)
                colUzel = 0;

            if (colUzel == 0)
                dout = HelpGraph.DeserialGraph();
            else
                dout = new Graph(colUzel);

            //HelpGraph.SerialGraph(dout);
            Console.WriteLine();
            Pathes result = GenomAlgoritm.LocateMinPath(dout);
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Вероятно крадчайший путь идет через города:");
            foreach (var item in result.chain)
                Console.Write($"{item+1} => ");
            Console.WriteLine($"Весь путь = {result.longPath}");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadLine();
        }
    }
}
