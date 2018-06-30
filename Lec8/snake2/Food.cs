using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec6
{
    public class Food:GameObject
    {
        Random rnd = new Random();

        public Food()
        {
            sign = '@';
            GenerateNewFood();
        }

        public void GenerateNewFood()
        {
            Point p = new Point { X = rnd.Next(0, 49), Y = rnd.Next(0, 49) };
            body.Clear();
            body.Add(p);
        }
    }
}
