using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec6G2
{
    class Point
    {
        private int x;
        private int y;
        public int X {
            get
            {
                return x;
            }
            set
            {
                if (value >= 50)
                {
                    x = 0;
                }
                else if (value < 0)
                {
                    x = 49;
                }
                else
                {
                    x = value;
                }
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value >= 50)
                {
                    y = 0;
                }
                else if (value < 0)
                {
                    y = 49;
                }
                else
                {
                    y = value;
                }
            }
        }

        public override bool Equals(object obj)
        {
            Point a = obj as Point;
            return a.X == X && a.Y == Y;
        }
    }
}
