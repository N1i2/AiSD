using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRebra
{
    class Rebra
    {
        public Rebra(int fDut, int lend, int sDout)
        {
            firstDout = fDut;
            longRebr = lend;
            secondDout = sDout;
        }

        public Rebra(Rebra re)
        {
            firstDout += re.firstDout;
            longRebr += re.longRebr;
            secondDout += re.secondDout;
        }

        public int firstDout { get; set; }
        public int secondDout { get; set; }
        public int longRebr { get; set; }
    }
}
