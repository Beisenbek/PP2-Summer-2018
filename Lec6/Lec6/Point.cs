﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec6
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override bool Equals(object obj)
        {
            Point b = obj as Point;
            return X == b.X && Y == b.Y;
        }
    }
}
