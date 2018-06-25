using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec6
{
    class Wall : GameObject
    {
        public Wall()
        {
            sign = '#';
            GenerateWall(1);
        }

        public void GenerateWall(int level)
        {
            string path = string.Format("Level{0}.txt", level);
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    for (int i = 0; i < 50; ++i)
                    {
                        string line = sr.ReadLine();
                        for(int j = 0; j < 50; ++j)
                        {
                            if(line[j] == '#')
                            {
                                body.Add(new Point { X = j, Y = i });
                            } 
                        }
                    }
                }
            }
        }
    }
}
