using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDout
{
    class Dout
    {
        public Dout(int index,char simbl, params (int adress, int lendths)[] rebrs)
        {
            id = index;
            doutSimbl = simbl;
            size = rebrs.Length;
            Rebr = rebrs;
        }

        public readonly int id;
        public readonly char doutSimbl;
        private int[] doutsRebr;
        public readonly int size;
        private int[] rebrLendth;

        public (int, int)[] Rebr
        {
            set
            {
                doutsRebr = new int[size];
                rebrLendth = new int[size];

                for (int i = 0; i < size; i++)
                {
                    doutsRebr[i] = value[i].Item1;
                    rebrLendth[i] = value[i].Item2;
                }
            }
        }

        public int GetRabr(int index)
        {
            return doutsRebr[index];
        }

        public int GetLeth(int index)
        {
            return rebrLendth[index];
        }
    }
}
