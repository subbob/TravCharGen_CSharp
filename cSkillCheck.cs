using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cSkillCheck : cBaseCheck
    {
        // Public Properties
        public string BaseSkill;
        // Private Properties

        // Public Methods
        public bool Success(cPlayer PC)
        {
            if ((PC.Stats.GetStat(BaseSkill) + Total_DM(PC)) >= Target)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Private Methods

    }
}
