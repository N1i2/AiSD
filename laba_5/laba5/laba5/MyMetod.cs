using MyRebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metods
{
    static class MyMetod
    {
        public static void AddFullRebr(List<Rebra> rebr)
        {
            rebr.Clear();
            rebr.Add(new Rebra(1, 2, 2));
            rebr.Add(new Rebra(1, 8, 4));
            rebr.Add(new Rebra(1, 2, 5));
            rebr.Add(new Rebra(2, 3, 3));
            rebr.Add(new Rebra(2, 10, 4));
            rebr.Add(new Rebra(2, 5, 5));
            rebr.Add(new Rebra(3, 12, 5));
            rebr.Add(new Rebra(3, 7, 8));
            rebr.Add(new Rebra(4, 14, 5));
            rebr.Add(new Rebra(4, 3, 6));
            rebr.Add(new Rebra(4, 1, 7));
            rebr.Add(new Rebra(5, 11, 6));
            rebr.Add(new Rebra(5, 4, 7));
            rebr.Add(new Rebra(5, 8, 8));
            rebr.Add(new Rebra(6, 6, 7));
            rebr.Add(new Rebra(7, 9, 8));
        }

        public static Rebra LocateMin(List<Rebra> rebr, int[] howCheck, bool second = false)
        {
            Rebra res = rebr[0];

            for (int i = 0, help = int.MaxValue; i < rebr.ToArray().Length; i++)
                if (rebr[i].longRebr < help &&
                    howCheck[rebr[i].firstDout] < 2 &&
                    howCheck[rebr[i].secondDout] < 2)
                {
                    help = rebr[i].longRebr;
                    res = rebr[i];
                }

            howCheck[res.firstDout]++;
            howCheck[res.secondDout]++;
            if (second && howCheck[res.firstDout] == 2)
            {
                howCheck[res.firstDout]++;
                DeleteRebr(rebr, res.firstDout);
            }
            if (second && howCheck[res.secondDout] == 2)
            {
                howCheck[res.secondDout]++;
                DeleteRebr(rebr, res.secondDout);
            }

            return res;
        }

        public static void DeleteRebr(List<Rebra> rebrs, int rebr)
        {
            for (int i = 0; i < rebrs.Count; i++)
                if (rebrs[i].firstDout == rebr || rebrs[i].secondDout == rebr)
                    rebrs.Remove(rebrs[i]);
        }

        public static void AddCheck(List<Rebra> rebr, List<Rebra> check, int locate1, int locate2)
        {
            for (int i = 0; i < rebr.Count; i++)
            {
                if ((rebr[i].firstDout == locate1 ||
                    rebr[i].secondDout == locate1) &&
                    !check.Contains(rebr[i]))
                    check.Add(rebr[i]);

                if ((rebr[i].firstDout == locate2 ||
                    rebr[i].secondDout == locate2) &&
                    !check.Contains(rebr[i]))
                    check.Add(rebr[i]);
            }
        }

        public static void ShowTree(Rebra[] result)
        {
            for (int i = 0; i < result.Length; i++)
                Console.WriteLine($"{result[i].firstDout}=={result[i].secondDout}");
        }
    }
}
