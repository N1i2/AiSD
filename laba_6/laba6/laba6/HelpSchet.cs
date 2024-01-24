using laba6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
    static class HelpSchet
    {
        static public void LocateSimvl(List<int> schet, List<char> simvl, string text)
        {
            List<int> numb = new List<int>();
            List<char> sim = new List<char>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!sim.Contains(text[i]))
                {
                    numb.Add(1);
                    sim.Add(text[i]);
                    continue;
                }

                numb[sim.IndexOf(text[i])]++;
            }

            for (int i = 0, j = numb.ToArray().Length; i < j; i++)
            {
                int max = numb.IndexOf(numb.Max());
                simvl.Add(sim[max]);
                schet.Add(numb[max]);
                sim.Remove(sim[max]);
                numb.Remove(numb[max]);
            }
        }

        static public void ShowAllSimvol(List<int> schet, List<char> sim, string text, bool prozent = false)
        {
            Console.WriteLine(text);
            Console.WriteLine(text.Length);
            if (prozent)
                for (int i = 0, j = sim.ToArray().Length; i < j; i++)
                {
                    Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Red : ConsoleColor.Cyan;
                    string need = (sim.ToArray()[i] != ' ') ? sim.ToArray()[i].ToString() : "PROBEL";
                    Console.WriteLine($"{need} \t== {(float)(schet.ToArray()[i] * 100f / text.Length)}%");
                }
            else
                for (int i = 0, j = sim.ToArray().Length; i < j; i++)
                {
                    Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Red : ConsoleColor.Cyan;
                    string need = (sim.ToArray()[i] != ' ') ? sim.ToArray()[i].ToString() : "PROBEL";
                    Console.WriteLine($"{need} \t== {schet.ToArray()[i]}");
                }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine('\n');
        }

        static public void ShowCodes(List<char> sim, string[] codes)
        {
            Console.WriteLine("Коды");
            for (int i = 0; i < codes.Length; i++)
            {
                Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Red : ConsoleColor.Cyan;
                string need = (sim.ToArray()[i] != ' ') ? sim.ToArray()[i].ToString() : "PROBEL";
                Console.WriteLine($"{need} \t== {codes[i]}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static public HuffmansTree LocateMin(List<HuffmansTree> eles)
        {
            HuffmansTree min = eles[eles.ToArray().Length - 1];
            for (int i = eles.ToArray().Length - 2; i >= 0; i--)
                if (min.vess > eles[i].vess)
                    min = eles[i];

            eles.Remove(min);

            return min;
        }

    }
}
