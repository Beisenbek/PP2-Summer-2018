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


            System.Timers.Timer timer = new System.Timers.Timer(100);
            timer.Elapsed += snake.Move;
            timer.Start();

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
                    case ConsoleKey.F2:
                        snake.Save();
                        break;
                    case ConsoleKey.F3:
                        Console.Clear();
                        food.Draw();
                        wall.Draw();
                        timer.Stop();
                        timer.Elapsed -= snake.Move;
                        snake = snake.Load();
                        snake.SetFood(food);
                        timer.Elapsed += snake.Move;
                        timer.Start();
                        break;
                }
            }
        }
    }
}
