using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec5G2
{
    class StackItem2
    {
        int index;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                if (value < 0)
                {
                    index = 0;
                }
                else if (value >= DirInfo.GetFileSystemInfos().Length)
                {
                    index = DirInfo.GetFileSystemInfos().Length - 1;
                }
                else
                {
                    index = value;
                }
            }
        }
        public DirectoryInfo DirInfo
        {
            get;
            set;
        }
    }
}
