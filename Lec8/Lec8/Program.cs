using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Lec8
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += DoIt;
            timer.Enabled = true;

            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.Spacebar:
                        timer.Stop();
                        break;
                    case ConsoleKey.Enter:
                        timer.Start();
                        break;
                }
            }
        }

        private static void DoIt(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString());
        }
    }
}
