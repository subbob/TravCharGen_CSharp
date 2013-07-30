using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
    public class cPrint
    {
        public static bool LogMode = false;
        public static string LogFileName = "MyLibLog.txt";
        private static System.IO.StreamWriter LogFile;
        static private bool Initialized = false;
        
        public void SetLogMode(bool NewMode)
        {
            LogMode = true;
        }

        public void PrintLine(string TextLine)
        {
            Console.WriteLine(TextLine);
            //System.IO.File.AppendText

            if (LogMode)
            {
                using (System.IO.StreamWriter LogFile = System.IO.File.AppendText(LogFileName))
                {
                    LogFile.WriteLine(TextLine);
                }
            }
        }

        public cPrint()
        {
            if (!Initialized)
            {
                if (!System.IO.File.Exists(LogFileName))
                {
                    // Create a file to write to. 
                    using (System.IO.StreamWriter LogFile = System.IO.File.CreateText(LogFileName))
                    {
                        LogFile.WriteLine("New log file started\n\n");
                    }
                }
                else
                {
                    using (System.IO.StreamWriter LogFile = System.IO.File.AppendText(LogFileName))
                    {
                        LogFile.WriteLine("\nAppending to the log file\n\n");
                    }
                }
            }
        }
    }
}
