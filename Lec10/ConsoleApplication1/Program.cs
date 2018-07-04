using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer p = new Printer(PrintToConsole);
            p.Print("hello world!");
        }
        static void PrintToConsole(string m)
        {
            Console.WriteLine(m);
        }
    }

    public delegate void MyDelegate(string msg);

    class Printer
    {
        MyDelegate d;
        public Printer(MyDelegate d)
        {
            this.d = d;
        }

        public void Print(string msg)
        {
            d.Invoke(msg + "!!!!");
        }
    }
}
