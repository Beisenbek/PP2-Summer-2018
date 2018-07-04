using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Utils
    {
        public static bool IsNonZeroDigit(string x)
        {
            if (x.Length == 1 && x[0] <= '9' && x[0] > '0') return true;
            return false;
        }

        public static bool IsDigit(string x)
        {
            if (x.Length == 1 && x[0] <= '9' && x[0] >= '0') return true;
            return false;
        }

        public static bool IsZero(string x)
        {
            if (x.Length == 1 && x[0] == '0') return true;
            return false;
        }

        public static bool IsOperation(string x)
        {
            if (x.Length == 1 && x[0] == '+') return true;
            return false;
        }

        public static bool IsResult(string x)
        {
            if (x.Length == 1 && x[0] == '=') return true;
            return false;
        }
    }
}
