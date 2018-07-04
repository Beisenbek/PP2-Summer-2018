using L10G2;
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
            Printer printer = new Printer(PrintToConsole);
            printer.Print("hi!");  
        }

        static void PrintToConsole(string x)
        {
            Console.WriteLine(x);
        }
    }
}
