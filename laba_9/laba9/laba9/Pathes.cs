using MyGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPath
{
    class Pathes
    {
        public Pathes(int[] path, Graph dout)
        {
            chain = path;
            longPath = CreatLongPath(path, dout);
        }

        public int[] chain { get;private set; }
        public int longPath { get;private set; }

        static private int CreatLongPath(int[] chain, Graph perent)
        {
            int result = 0;

            for (int i = 0, j = 1; j < chain.Length; i++, j++)
                result += perent.dout[chain[i]].path[chain[j]];

            return result;
        }
    }
}
