using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class MarinesServiceData : cServiceData
    {

        public MarinesServiceData()
        {
            Enlistment.Target = 9;
            Enlistment.Add_Mod(1, "INT", 8);
            Enlistment.Add_Mod(2, "STR", 8);

            Survival.Target = 6;
            Survival.Add_Mod(2, "END", 8);

            Commission.Target = 9;
            Commission.Add_Mod(1, "EDU", 7);

            Promotion.Target = 9;
            Promotion.Add_Mod(1, "SOC", 8);

            Reenlist.Target = 6;

            OfficerCorps = true;

            Ranks = new string[] {"Lieutenant","Captain","Force Cmdr","Lt Colonel","Colonel","Brigadier"};
        }
    }
}
