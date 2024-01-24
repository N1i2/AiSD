using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Help;

namespace laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            const string TEST_NAME = "selicky nikolay eugenievich";

            List<char> simvl = new List<char>();
            List<int> schet = new List<int>();

            HelpSchet.LocateSimvl(schet, simvl, TEST_NAME);

            HelpSchet.ShowAllSimvol(schet, simvl, TEST_NAME);
            HelpSchet.ShowAllSimvol(schet, simvl, TEST_NAME, true);

            List<HuffmansTree> elements = new List<HuffmansTree>();
            for (int i = 0; i < schet.ToArray().Length; i++)
                elements.Add(new HuffmansTree(schet.ToArray()[i], simvl.ToArray()[i]));

            CreatTree(elements);
            string[] codes = new string[simvl.Count];
            CreatCodeTable(codes, simvl, elements[0]);

            HelpSchet.ShowCodes(simvl, codes);

            Console.WriteLine("\n\n{0}", CodingMessage(TEST_NAME, simvl, codes));

            Console.ReadLine();
        }

        static public void CreatTree(List<HuffmansTree> elements)
        {
            while (elements.Count > 1)
                elements.Add(new HuffmansTree(HelpSchet.LocateMin(elements), HelpSchet.LocateMin(elements)));
        }

        static  public void CreatCodeTable(string[] schet, List<char> simble, HuffmansTree uzel, string code = "")
        {
            if (uzel.simvl != null)
            {
                schet[simble.IndexOf(uzel.simvl ?? ' ')] =code;

                return;
            }

            CreatCodeTable(schet, simble, uzel.rightChild, code += '1');

            string help = code;
            code = "";
            for (int i = 0; i < help.Length - 1; i++)
                code += help[i];

            CreatCodeTable(schet, simble, uzel.leftChild, code += '0');
        }

        static public string CodingMessage(string text, List<char> sim, string[] codes)
        {
            string result = "";

            for(int i =0;i<text.Length;i++)
                result += codes[sim.IndexOf(text[i])];

            return result;
        }
    }
}
