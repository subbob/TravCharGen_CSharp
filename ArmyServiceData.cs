using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class ArmyServiceData : cServiceData
    {

        public ArmyServiceData()
        {
            Enlistment.Target = 5;
            Enlistment.Add_Mod(1, "DEX", 6);
            Enlistment.Add_Mod(2, "END", 5);

            Survival.Target = 5;
            Survival.Add_Mod(2, "EDU", 6);

            Commission.Target = 5;
            Commission.Add_Mod(1, "END", 7);

            Promotion.Target = 6;
            Promotion.Add_Mod(1, "EDU", 7);

            Reenlist.Target = 7;

            OfficerCorps = true;

            Ranks = new string[] { "Lieutenant", "Captain", "Major", "Lt Colonel", "Colonel", "General" };
        }
    }
}
