using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    class Character
    {
        MyLib.cPrint OutFile = new MyLib.cPrint();
        private static int Population;

        public string Name;

        public int TotalCharacters()
        {
            return Population;
        }

        public Character(string NewName)
        {
            Name = NewName;
            Population++;
        }
        static Character()
        {
            Population = 0;
        }

        public void PrintCharacters()
        {
            OutFile.PrintLine("Character: " + this.Name + "(" + this.GetPopulation().ToString() + ")");
        }

        public int GetPopulation()
        {
            return Population;
        }

    }
}
