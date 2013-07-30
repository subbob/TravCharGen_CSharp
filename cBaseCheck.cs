using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cBaseCheck
    {
        // Public Properties
        public int Target;
        protected List<cDM> Mods = new List<cDM> { };
        // Private Properties

        // Public Methods

        public int Total_DM(cPlayer PC)
        {
            int temp = 0;
            foreach (cDM item in Mods)
            {
                temp += item.Value(PC);
            }
            return temp;
        }

        public void Add_Mod(int arg_DM, string arg_Stat, int arg_Target, bool arg_SkillCheck = false)
        {
            cDM temp = new cDM(arg_DM, arg_Stat, arg_Target, arg_SkillCheck);
            Mods.Add(temp);
        }
        // Private Methods

        // Default Constructor

    }
}
