using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    class MyList<T>: List<T>
    {
        public override bool Equals(object obj)
        {
            bool ok = true;

            if(obj is List<T>)
            {
                List<T> l2 = obj as List<T>;
                for (int i = 0; i < l2.Count; ++i)
                {
                    int a = int.Parse(l2[i].ToString());
                    int b = int.Parse(this[i].ToString());

                    if (a != b)
                    {
                        ok = false;
                        break;
                    }
                }
            }
            

            return ok;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int y = 5;
            Console.WriteLine(x == y);

            MyList<int> l1 = new MyList<int>();
            l1.Add(5);
            MyList<int> l2 = new MyList<int>();
            l2.Add(5);


            Console.WriteLine(l1 == l2);
            Console.WriteLine(l1.Equals(l2));
        }
    }
}
