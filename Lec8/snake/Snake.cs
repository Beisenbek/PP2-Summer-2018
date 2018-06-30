using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace Lec6
{
    public class Snake:GameObject
    {
        public int dx = 0;
        public int dy = 0;
        Food food;

        public Snake()
        {

        }
        public Snake(Food food)
        {
            this.food = food;

            sign = '*';
            Point head = new Point();
            head.X = 12;
            head.Y = 12;
            body.Add(head);
        }

        public void SetFood(Food food)
        {
            this.food = food;
        }

        public void Move(object sender, ElapsedEventArgs e)
        {
            Clear();

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i] = new Point { X = body[i - 1].X, Y = body[i - 1].Y };
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
        }

        public Snake Reload()
        {
            Snake res = null;
            using (FileStream fs = new FileStream("snake.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Snake));
                res = xs.Deserialize(fs) as Snake;
            }

            return res;
        }

        public void Save()
        {
            using (FileStream fs = new FileStream("snake.xml", FileMode.Create, FileAccess.ReadWrite))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Snake));
                xs.Serialize(fs, this);
            }
        }

        public void Process(int dx, int dy)
        {
            this.dx = dx;
            this.dy = dy;
        }
    }
}
