using System;
using System.Threading;

namespace Lec6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(50, 50);
            Console.SetBufferSize(50, 50);
             
            Console.CursorVisible = false;

            Food food = new Food();
            Snake snake = new Snake(food);
            Wall wall = new Wall();
            
            food.Draw();
            wall.Draw();

            Thread t = new Thread(new ThreadStart(snake.Move));
            t.Start();

            while (true)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();

                switch (pressedButton.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Process(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Process(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Process(-1, 0);
                        break; 
                    case ConsoleKey.RightArrow:
                        snake.Process(1, 0);
                        break;
                    case ConsoleKey.F2:
                        snake.Save();
                        break;
                    case ConsoleKey.F3:
                        snake = snake.Reload();
                        snake.SetFood(food);
                        t.Abort();

                        Thread t2 = new Thread(new ThreadStart(snake.Move));
                        t2.Start();

                        break;
                }

            }
        }

    } 
}
