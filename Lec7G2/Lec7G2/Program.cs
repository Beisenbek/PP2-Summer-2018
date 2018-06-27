using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lec7G2
{
    public class Rectangle
    {
        [XmlIgnore]
        public int w;

        public int h;
        public override string ToString()
        {
            return string.Format("w: {0}, h: {1}", w, h);
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
            using (FileStream fs = new FileStream("rec2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Rectangle));
                Rectangle rec = xs.Deserialize(fs) as Rectangle;
                Console.WriteLine(rec);
            }
        }

        private static void F1()
        {
            Rectangle r = new Rectangle();
            r.w = 10;
            r.h = 20;

            using (FileStream fs = new FileStream("rec2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Rectangle));
                xs.Serialize(fs, r);
            }
        }
    }
}
