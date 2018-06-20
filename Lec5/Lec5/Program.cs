using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<StackItem2> history = new Stack<StackItem2>();
            StackItem2 item = new StackItem2 { DirInfo = new DirectoryInfo(@"C:\soft"), Index = 0 };
            VisualOperations visualOperations = new VisualOperations();
            visualOperations.VisualMode = VisualMode.DIR;
            history.Push(item);

            bool isOK = true;

            while (isOK)
            {

                if (visualOperations.VisualMode == VisualMode.DIR)
                {
                    VisualOperations.ShowInnerFileSystemInfo(history.Peek());
                }

                ConsoleKeyInfo pressedButton = Console.ReadKey();
                switch (pressedButton.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().Index = history.Peek().Index - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().Index = history.Peek().Index + 1;
                        break;
                    case ConsoleKey.Enter:

                        StackItem2 item2 = new StackItem2();
                        StackItem2 topItem = history.Peek();
                        FileSystemInfo[] info = topItem.DirInfo.GetFileSystemInfos();
                        FileSystemInfo fsObject = info[topItem.Index];
                        string path = fsObject.FullName;

                        if (fsObject is DirectoryInfo){
                            item2.DirInfo = new DirectoryInfo(path);
                            item2.Index = 0;
                            history.Push(item2);
                        }else if (fsObject is FileInfo)
                        {
                            visualOperations.VisualMode = VisualMode.FILE_CONTENT;
                            VisualOperations.ShowFileContent(path);
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (visualOperations.VisualMode == VisualMode.FILE_CONTENT)
                        {
                            visualOperations.VisualMode = VisualMode.DIR;
                        }
                        else
                        {
                            history.Pop();
                        }
                        break;
                    case ConsoleKey.Escape:
                        isOK = false;
                        break;
                }
            }
        }
    }
}
