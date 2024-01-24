using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGraph;
using System.Runtime.Serialization.Formatters.Soap;

namespace laba_9
{
    static class HelpGraph
    {
        static HelpGraph()
        {
            adres = "..\\..\\file.xml";
        }

        static private string adres;
        static private SoapFormatter ser = new SoapFormatter();

        static public void SerialGraph(Graph info)
        {
            using (FileStream file = new FileStream(adres, FileMode.Create))
            {
                ser.Serialize(file, info);
            }
        }
        static public Graph DeserialGraph()
        {
            Graph graph;

            using (FileStream file = new FileStream(adres, FileMode.Open))
            {
                graph = ser.Deserialize(file) as Graph;
            }

            return graph;
        }
    }
}
