using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Brain b = new Brain(PrintToConsole);

            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                b.Process(pressedKey.Key.ToString());
            }

        }

        static void PrintToConsole(string text)
        {
            Console.WriteLine(text);
        }
    }
}
