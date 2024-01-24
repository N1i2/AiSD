using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyRebra;
using Metods;

//прима
//краскала

namespace laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            const int UZEL = 8;
            List<Rebra> rebr = new List<Rebra>();
            List<Rebra> check = new List<Rebra>();

            MyMetod.AddFullRebr(rebr);

            int[] howCheck = new int[rebr.Count];
            Rebra[] result = new Rebra[rebr.ToArray().Length - UZEL - 1];
            Rebra help = MyMetod.LocateMin(rebr, howCheck);

            result[0] = help;
            rebr.Remove(help);

            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& ПРИМА &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            for (int i = 1; i < result.Length; i++)
            {
                MyMetod.AddCheck(rebr, check,
                    result[i - 1].firstDout, result[i - 1].secondDout);
                help = MyMetod.LocateMin(check, howCheck);

                result[i] = help;
                rebr.Remove(help);
                check.Remove(help);
            }

            //################################ КРАСКАЛА ###########################################
            MyMetod.ShowTree(result);
            MyMetod.AddFullRebr(rebr);

            result = new Rebra[result.Length];
            howCheck = new int[howCheck.Length];

            for (int i = 0; i < result.Length; i++)
            {
                help = MyMetod.LocateMin(rebr, howCheck, true);
                rebr.Remove(help);
                result[i] = help;
            }

            Console.WriteLine("\n".PadRight(50, '/'));
            MyMetod.ShowTree(result);
        }
    }
}
