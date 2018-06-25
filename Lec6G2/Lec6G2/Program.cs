using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lec6G2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(50, 50);
            Console.CursorVisible = false;
            Console.SetBufferSize(50, 50);

            Food food = new Food();
            Snake snake = new Snake(food);
            Wall wall = new Wall();
            wall.Draw();
            food.Draw();

            ThreadStart ts = new ThreadStart(snake.Move);
            Thread t = new Thread(ts);
            t.Start();
            

            while (true)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                switch (pressedButton.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Dy = -1;
                        snake.Dx = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Dy = 1;
                        snake.Dx = 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Dy = 0;
                        snake.Dx = -1;
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Dy = 0;
                        snake.Dx = 1;
                        break;
                }
            }
        }
    }
}
