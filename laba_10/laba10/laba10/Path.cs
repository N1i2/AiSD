using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    class Path
    {
        public Path(char f, char s, int pher)
        {
            Dot[0] = f;
            Dot[1] = s;
            Lenght = ranada.Next(1, 11);
            Pheramon = pher;
        }

        Random ranada = new Random();

        public char[] Dot { get; set; } = new char[2];
        public int Lenght { get; set; }
        public double Pheramon { get; set; }

        static public void ShowAllDot(List<Path> dotes)
        {
            foreach (Path path in dotes)
                Console.WriteLine(path.Dot[0] + " == " + path.Dot[1] + " = " + path.Lenght + " (" + path.Pheramon + ")");
        }
    }
}
