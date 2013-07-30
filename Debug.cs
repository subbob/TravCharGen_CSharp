using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
    public class Debug
    {
        private static MyLib.cPrint OutFile = new MyLib.cPrint();
        private static bool DebugMode = true;

	    public void PrintMsg (string msg)
		{
            if (DebugMode)
            {
                OutFile.PrintLine("\n\t***\t" + msg + "\t***\n");
            }
		}

        public bool Mode()
        {
            return DebugMode;
        }

        public void ToggleMode()
        {
            DebugMode = !DebugMode;
        }

        public void DebugOn()
        {
            DebugMode = true;
        }

        public void DebugOff()
        {
            DebugMode = false;
        }
    }


}
