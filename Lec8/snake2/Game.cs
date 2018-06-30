using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Lec6
{
    enum GameMode
    {
        menu,
        game
    }

    class Game
    {
        public GameMode mode { get; set; }
        public bool IsActive { get; set; }
        Menu menu = new Menu();
        Food food;
        Snake snake;
        Wall wall;
        Timer timer;

        public void Start()
        {
            food.Draw();
            wall.Draw();

            Timer timer = new Timer(100);
            timer.Enabled = true;
           // timer.Elapsed += snake.Move;
        }

        public void Process(ConsoleKeyInfo pressedButton)
        {
            if(mode == GameMode.menu)
            {
                menu.Draw();
            }
            switch (pressedButton.Key)
            {
                case ConsoleKey.Escape:
                    timer.Stop();
                    mode = GameMode.menu;
                    menu.Draw();
                    break;
                case ConsoleKey.Enter:
                    if(mode == GameMode.menu)
                    {
                        if(menu.SelectedItem == MenuItem.New)
                        {
                            NewGame();
                        }
                    }
                    break;
                case ConsoleKey.UpArrow:
                   if(mode == GameMode.menu)
                    {
                        menu.SelectedItem--;
                    }
                    else if(mode == GameMode.game)
                    {
                        snake.Process(0, -1);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (mode == GameMode.menu)
                    {
                        menu.SelectedItem++;
                    }
                    else if (mode == GameMode.game)
                    {
                        snake.Process(0, 1);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (mode == GameMode.game)
                    {
                        snake.Process(-1, 0);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (mode == GameMode.game)
                    {
                        snake.Process(1, 0);
                    }
                    break;
            }
            
        }

        private void NewGame()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            mode = GameMode.game;

            food = new Food();
            wall = new Wall();
            snake = new Snake(food);
            timer = new Timer(100);

            food.Draw();
            wall.Draw();
            timer.Elapsed += snake.Move;
            timer.Start();
        }

        public Game()
        {
            Console.SetWindowSize(50, 50);
            Console.SetBufferSize(50, 50);
            Console.CursorVisible = false;
            IsActive = true;
            mode = GameMode.menu;
            menu.Draw();
        }
    }
}
