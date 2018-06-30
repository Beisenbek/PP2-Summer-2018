using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec6G2
{
    public class Food : GameObject
    {
        public Food()
        {
            sign = '@';
            Random rnd = new Random();
            body.Clear();
            body.Add(new Point { X = rnd.Next(0, 49), Y = rnd.Next(0, 49) });
        }
    }
}
