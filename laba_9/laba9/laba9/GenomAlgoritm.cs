using MyGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyPath;

namespace MyGenom
{
    static class GenomAlgoritm
    {
        static private Random ranada = new Random();
        static public Pathes LocateMinPath(Graph populer)
        {
            int col = populer.dout.Length;
            Pathes[] result = new Pathes[col];
            Pathes[] pathes = new Pathes[col];

            for (int r = 0; r < result.Length; r++)
            {
                List<int[]> list = new List<int[]>();
                int[] help;
                for (int c = 0; c < col; c++)
                {
                    help = Enumerable.Range(0, col).OrderBy(numb =>ranada.Next()).ToArray();

                    if (list.Contains(help))
                    {
                        c--;
                        continue;
                    }

                    list.Add(help);

                    pathes[c] = new Pathes(help, populer);
                }
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Популяция №{0}", r+1);
                Console.ForegroundColor = ConsoleColor.Red;

                for (int i = 0; i < col; i++)
                {
                    foreach (var item in pathes[i].chain)
                        Console.Write(item + 1);
                    Console.WriteLine($" = {pathes[i].longPath}");
                }
                Console.ForegroundColor = ConsoleColor.White;

                result[r] = CreatChildren(LocatePerents(pathes), populer);

                Console.WriteLine("Крадчайший в популяции: ");
                foreach (var item in result[r].chain)
                    Console.Write((item+1)+" => ");
                Console.WriteLine(result[r].longPath);
            }

            result = result.OrderBy(path => path.longPath).ToArray();

            return result[0];
        }

        static private Pathes CreatChildren((Pathes mother, Pathes fother) perets, Graph dout)
        {
            int[] firstChain = CreatChildrenChain(perets.mother.chain, perets.fother.chain);
            int[] secondChain = CreatChildrenChain(perets.fother.chain, perets.mother.chain);


            Pathes firstChildren = new Pathes(firstChain, dout);
            Pathes secondChildren = new Pathes(secondChain, dout);

            firstChildren = Mutashen(firstChildren, dout);
            secondChildren = Mutashen(secondChildren, dout);

            return (firstChildren.longPath <= secondChildren.longPath) ? firstChildren : secondChildren;
        }
        static private (Pathes mother, Pathes fother) LocatePerents(Pathes[] pathes)
        {
            pathes = pathes.OrderBy(path => path.longPath).ToArray();

            Pathes mother = pathes[0];
            Pathes fother = pathes[ranada.Next(1, pathes.Length)];

            return (mother, fother);
        }
        static private int[] CreatChildrenChain(int[] mother, int[] fother)
        {
            bool[] use = Enumerable.Repeat(true, mother.Length).ToArray();
            List<int> result = new List<int>();
            bool moth = true;

            for (int i = 0; i < mother.Length; i++)
            {
                if (moth)
                {
                    result.Add(mother[i]);
                    use[mother[i]] = false;

                    if (mother[i] != fother[i])
                        moth = false;

                    continue;
                }

                if (use[fother[i]])
                {
                    use[fother[i]] = false;
                    result.Add(fother[i]);
                }
            }

            for (int i = 0; i < use.Length && result.Count != use.Length; i++)
                if (use[i])
                    result.Add(i);
            result.Add(result[0]);

/*            foreach (var item in result)
                Console.Write(item);
            Console.WriteLine('\n');*/

            return result.ToArray();
        }
        static private Pathes Mutashen(Pathes path, Graph dout)
        {
            int[] helpC=new int[path.chain.Length];
            path.chain.CopyTo(helpC, 0);
            int first = ranada.Next(1, path.chain.Length-1);
            int second = ranada.Next(1, path.chain.Length-1);

            int help = helpC[first];
            helpC[first] = helpC[second];
            helpC[second] = help;

            Pathes helpP=new Pathes(helpC, dout);

            return (path.longPath<=helpP.longPath)?path:helpP;
        }
    }
}
