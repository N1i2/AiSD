using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    internal class AntAlgorithm
    {
        static private int count = 0;
        static private double cofIspor = 0.7;
        static public (string, int) StrtAlgoritm(List<Path> pathes, string needTxt, int a, int b)
        {
            string[] pointPath = new string[needTxt.Length];
            int[] length = new int[needTxt.Length];

            for (int i = 0; i < needTxt.Length; i++)
            {
                pointPath[i] = GetOneTock(pathes, needTxt, needTxt[i], a, b);
                length[i] = GetLenght(pathes, pointPath[i]);
            }

            int ansver = length.ToList().IndexOf(length.Min());
            Console.WriteLine("Заход под номером " + (++count));
            for (int i = 0; i < length.Length; i++)
            {
                if (i == ansver)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(pointPath[i] + " == " + length[i] + "  ЛУЧШИЙ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                Console.WriteLine(pointPath[i] + " == " + length[i]);
            }

            return (pointPath[ansver], length[ansver]);
        }
        static private string GetOneTock(List<Path> pathes, string needTxt, char start, int a, int b)
        {
            char str = start;
            string notneed = "";
            List<Path> path;
            bool need;

            for (int i = 0; i < needTxt.Length; i++)
            {
                path = new List<Path>();
                foreach (Path p in pathes)
                    if (p.Dot.Contains(str))
                    {
                        need = true;

                        for (int j = 0; j < notneed.Length; j++)
                            if (p.Dot.Contains(notneed[j]))
                            {
                                need = false;
                                break;
                            }
                        if (!need)
                            continue;

                        path.Add(p);
                    }

                notneed += str;

                if (path.Count != 0)
                {
                    int goTo = GetReason(path, a, b);
                    str = (path[goTo].Dot[0] != str) ? path[goTo].Dot[0] : path[goTo].Dot[1];
                }
            }

            notneed += notneed[0];

            return notneed;
        }
        static private int GetReason(List<Path> path, int a, int b)
        {
            double sum = 0;
            double[] result = new double[path.Count];

            Random random = new Random();

            foreach (var p in path)
                sum += Math.Pow(p.Lenght, a) * Math.Pow(p.Pheramon, b);

            for (int i = 0; i < result.Length; i++)
                result[i] = (Math.Pow(path[i].Lenght, a) * Math.Pow(path[i].Pheramon, b)) / sum;

            double k = random.Next(1, 101) / 100d;

            sum = 0;

            for (int i = 0; i < result.Length; i++)
            {
                sum += result[i];
                if (sum >= k)
                {
                    return i;
                }
            }

            return result.Length;
        }
        static private int GetLenght(List<Path> pathes, string path)
        {
            int result = 0;

            for (int i = 0; i < (path.Length - 1); i++)
                foreach (var p in pathes)
                    if (p.Dot.Contains(path[i]) && p.Dot.Contains(path[i + 1]))
                    {
                        result += p.Lenght;
                        break;
                    }

            return result;
        }
        static public void RecreatPheramon(List<Path> pathes, string bestPath, int bestlenght)
        {
            foreach (var p in pathes)
                p.Pheramon = p.Pheramon * cofIspor;

            double best = ((double)bestPath.Length / bestlenght) * 2d;

            for (int i = 0; i < bestPath.Length - 1; i++)
                foreach (var p in pathes)
                    if (p.Dot.Contains(bestPath[i]) && p.Dot.Contains(bestPath[i + 1]))
                    {
                        p.Pheramon += best;
                        break;
                    }
        }
    }
}
