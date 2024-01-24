using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraf
{
    internal class GrafD
    {
        private int[] _dout;

        public int[] Dout
        {
            get { return _dout; }

            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    _dout[i] = value[i];
                }
            }
        }

        public GrafD(int index, params int[] dout)
        {
            _dout = new int[index];

            Dout = dout;
        }
    }
}
