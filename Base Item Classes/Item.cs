using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class Item
    {
        protected MyLib.cPrint OutFile = new MyLib.cPrint();
        protected string Name;
        protected int Value;

        public void Gain()
        {
            Value++;
        }

        public int GetValue()
        {
            return this.Value;
        }
        
        public void Print()
        {
            OutFile.PrintLine(this.Name + ": " + this.Value);
        }

        public string GetName()

        {
            return this.Name;
        }

        public void NewItem(string NewName, int NewValue = 0)
        {
            Name = NewName;
            Value = NewValue;
        }

    }
}
