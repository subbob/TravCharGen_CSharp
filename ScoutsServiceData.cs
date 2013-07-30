using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class ScoutsServiceData : cServiceData
    {

        public ScoutsServiceData()
        {
            Enlistment.Target = 7;
            Enlistment.Add_Mod(1, "INT", 6);
            Enlistment.Add_Mod(2, "STR", 8);

            Survival.Target = 7;
            Survival.Add_Mod(2, "END", 9);

            Commission.Target = 13;
            //Commission.Add_Mod(1, "SOC", 9);

            Promotion.Target = 13;
            //Promotion.Add_Mod(1, "EDU", 8);

            Reenlist.Target = 3;

            OfficerCorps = false;

            Ranks = new string[] {"--","--","--","--","--","--"};
        }
    }
}
