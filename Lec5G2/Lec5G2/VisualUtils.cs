using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec5G2
{
    enum VisualMode
    {
        List,
        Content
    }
    class VisualUtils
    {
        public VisualMode VisualMode { get; set; } //1 - List 2 - Content
        public static void ShowFileSystemInfo(StackItem2 item)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileSystemInfo[] objs = item.DirInfo.GetFileSystemInfos();

            for (int i = 0; i < objs.Length; ++i)
            {
                if(objs[i] is DirectoryInfo)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                if (i == item.Index)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(objs[i].Name);
            }
        }

        public static void ShowFileContent(string path)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
}
