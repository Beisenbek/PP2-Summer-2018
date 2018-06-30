using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec6
{
    public enum MenuItem
    {
        New = 0,
        Load = 1, 
        Save = 2,
        Exit = 3
    }

    public class Menu
    {
        private MenuItem selectedItem;
        public MenuItem SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if(value < 0)
                {
                    selectedItem = (MenuItem)3;
                }else if((int)value >= 4)
                {
                    selectedItem = 0;
                }
                else
                {
                    selectedItem = value;
                }
            }
        }
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();

            for (int i = 0; i < 4; ++i)
            {
                Console.SetCursorPosition(14, 10 + i);

                if (selectedItem == (MenuItem)i)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine((MenuItem)i);
            }
        }
    }
}
