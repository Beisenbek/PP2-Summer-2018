using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lec6
{
    class Snake:GameObject
    {
        int dx = 0;
        int dy = 0;
        Food food;

        public Snake(Food food)
        {
            this.food = food;
            sign = '*';
            Point head = new Point();
            head.X = 12;
            head.Y = 12;
            body.Add(head);
        }

        public void Move()
        {
            while (true)
            {
                Clear();

                for (int i = body.Count - 1; i > 0; --i)
                {
                    body[i] = new Point { X = body[i - 1].X, Y = body[i - 1].Y};
                }

                body[0].X += dx;
                body[0].Y += dy;

                if (body[0].X < 0)
                {
                    body[0].X = 49;
                }
                if (body[0].Y < 0)
                {
                    body[0].Y = 49;
                }
                if (body[0].X > 49)
                {
                    body[0].X = 0;
                }
                if (body[0].Y > 49)
                {
                    body[0].Y = 0;
                }

                if (food.body[0].Equals(body[0]))
                {
                    body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });
                    food.GenerateNewFood();
                    food.Draw();
                }

                Draw();
                Thread.Sleep(100);
            }
        }

        public void Process(int dx, int dy)
        {
            this.dx = dx;
            this.dy = dy;
        }
    }
}
