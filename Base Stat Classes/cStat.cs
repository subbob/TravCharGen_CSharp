using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cStat
    {
        public const int MIN_Default = 1;
        public const int MAX_Default = 15;

        private static char[] HexCodes = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        public string Name {get ; private set;}
        public int Value { get; set; }
        private int MIN;
        private int MAX;

        public string AsText()
        {
            return Name + ": " + Value;
        }

        public string AsUPP()
        {
            return Name + ": " + HexCodes[Value];
        }

        public string AsTextWithUPP()
        {
            string tmp;
            if (Value > 9)
            {
                tmp = System.Convert.ToString(Value);
                tmp = tmp.PadRight(2);
                return Name + ": " + tmp + " (" + HexCodes[Value] + ")";                
            }
            else
            {
                tmp = System.Convert.ToString(Value);
                tmp= tmp.PadRight(2);
                return Name + ": " + tmp;
            }

        }

        public char ToHex()
        {
            return HexCodes[Value];
        }

        public void Set(string arg_Name, int arg_Value = 7, int arg_MIN = MIN_Default, int arg_MAX = MAX_Default)
        {
            Name = arg_Name;
            Value = arg_Value;
            MIN = arg_MIN;
            MAX = arg_MAX;
        }

        public void Set(int arg_Value)
        {
            Value = arg_Value;
        }

        public void Set(string arg_Name)
        {
            Name = arg_Name;
        }

        public static cStat operator ++(cStat arg)
        {
            arg.Value++;
            return arg;
        }

        public static cStat operator --(cStat arg)
        {
            arg.Value--;
            return arg;
        }

        public static bool operator >=(cStat arg1, int arg2)
        {
            return (arg1.Value >= arg2);
        }
        
        public static bool operator >(cStat arg1, int arg2)
        {
            return (arg1.Value > arg2);
        }

        public static bool operator <(cStat arg1, int arg2)
        {
            return (arg1.Value < arg2);
        }
        public static bool operator <=(cStat arg1, int arg2)
        {
            return (arg1.Value <= arg2);
        }
    }
}
