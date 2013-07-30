using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class NavyServiceData : cServiceData
    {

        public NavyServiceData()
        {
            Enlistment.Target = 8;
            Enlistment.Add_Mod(1, "INT", 8);
            Enlistment.Add_Mod(2, "EDU", 9);

            Survival.Target = 5;
            Survival.Add_Mod(2, "INT", 7);

            Commission.Target = 10;
            Commission.Add_Mod(1, "SOC", 9);

            Promotion.Target = 8;
            Promotion.Add_Mod(1, "EDU", 8);

            Reenlist.Target = 6;

            OfficerCorps = true;

            Ranks = new string[] {"Ensign","Lieutenant","Lt Cmdr","Commander","Captain","Admiral"};
        }
    }
}
