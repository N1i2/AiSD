using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    class HuffmansTree
    {
        public HuffmansTree(HuffmansTree min, HuffmansTree max)
        {
            vess = min.vess + max.vess;
            rightChild = min;
            leftChild = max;
        }
        public HuffmansTree(int vess, char simvl)
        {
            this.vess = vess;
            this.simvl = simvl;
            rightChild = null;
            leftChild = null;
        }

        public int vess { get; set; }
        public char? simvl { get; set; } = null;
        public HuffmansTree rightChild { get; set; }
        public HuffmansTree leftChild { get; set; }
    }
}
