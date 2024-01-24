using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace laba8
{
    static class Help
    {
        static private SoapFormatter soap = new SoapFormatter();
        static private string adres = "..\\..\\..\\file";

        static public void Sera(List<Belonging> elem)
        {
            using (FileStream file = new FileStream(adres+"3.txt", FileMode.Create))
            {
                soap.Serialize(file, elem);
            }
        }
        static public List<Belonging> Deser(int numb)
        {
            List<Belonging> list = new List<Belonging>();

            using (FileStream file = new FileStream(adres+numb+".txt", FileMode.Open))
            {
                list = soap.Deserialize(file) as List<Belonging>;
            }

            if (list == null)
                throw new Exception("Файл пуст");

            return list;
        }
    }
}
