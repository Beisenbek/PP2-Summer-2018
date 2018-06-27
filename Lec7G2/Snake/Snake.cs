using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lec6G2
{
    public class Snake:GameObject
    {
        public int Dx { get; set; }
        public int Dy { get; set; }

        private Food food;

        public void SetFood(Food food)
        {
            this.food = food;
        }

        public Snake()
        {

        }
        public Snake(Food food)
        {
            this.food = food;
            /*
            Point p = new Point();
            p.X = 12;
            p.Y = 12;*/
            body.Add(new Point { X = 12, Y = 12 });
            sign = 'o';
        }

        public void Move()
        {
            while (true)
            {
                Clear();

                for(int i = body.Count - 1; i > 0; --i)
                {
                    body[i] = new Point { X = body[i - 1].X, Y = body[i - 1].Y };
                }

                body[0].X += Dx;
                body[0].Y += Dy;

                if (food.body[0].Equals(body[0]))
                {
                    body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });
                    food = new Food();
                    food.Draw();
                }

                Draw();
                Thread.Sleep(100);
            }
        }

        public void Save()
        {
            using (FileStream fs = new FileStream("snake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Snake));
                xs.Serialize(fs, this);
            }
        }

        public Snake Load()
        {
            Snake res;
            using (FileStream fs = new FileStream("snake.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Snake));
                res = xs.Deserialize(fs) as Snake;
            }
            return res;
        }
    }
}
