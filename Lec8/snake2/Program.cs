using System;
using System.Timers;

namespace Lec6
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            while (game.IsActive)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                game.Process(pressedButton);
            }
        }

    }
}
