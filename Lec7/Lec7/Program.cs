using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lec7
{
    public class Rectangle
    {
        public int w;

        [XmlIgnore]
        public int h;

         public override string ToString()
        {
            return "w: " + w + " h:" + h;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F1();

        }

        private static void F2()
        {
            FileStream fs = new FileStream("rec.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Rectangle));
            Rectangle r = xs.Deserialize(fs) as Rectangle;
            fs.Close();
            Console.WriteLine(r);
        }

        private static void F1()
        {
            Rectangle r = new Rectangle();
            r.h = 12;
            r.w = 10;

            FileStream fs = new FileStream("rec.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Rectangle));
            xs.Serialize(fs, r);
            fs.Close();
        }
    }
}
