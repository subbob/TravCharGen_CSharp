using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class Skill : Item
    {

        //bool Cascade;
        string Description;

        public void Reset()
        {
            Value = 0;
        }

        public string AsText()
        {
            return Name + ": " + Value;
        }

        public Skill(string arg_Description = "None")
        {
            Description = arg_Description;
        }
    }
}
