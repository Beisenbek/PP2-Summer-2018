using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec5
{
    enum VisualMode
    {
        DIR,
        FILE_CONTENT
    }
    class VisualOperations
    {
        public VisualMode VisualMode { get; set; }//1-DIR, 2-FILE_CONTENT
        public static void ShowInnerFileSystemInfo(StackItem2 item)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileSystemInfo[] objects = item.DirInfo.GetFileSystemInfos();

            for (int i = 0; i < objects.Length; ++i)
            {
                if (i == item.Index)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(objects[i].Name);
            }
        }

        public static void ShowFileContent(string path)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
}
