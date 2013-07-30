using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class MerchantsServiceData : cServiceData
    {

        public MerchantsServiceData()
        {
            Enlistment.Target = 7;
            Enlistment.Add_Mod(1, "STR", 7);
            Enlistment.Add_Mod(2, "INT", 6);

            Survival.Target = 5;
            Survival.Add_Mod(2, "INT", 7);

            Commission.Target = 4;
            Commission.Add_Mod(1, "INT", 6);

            Promotion.Target = 10;
            Promotion.Add_Mod(1, "INT", 9);

            Reenlist.Target = 4;

            OfficerCorps = true;

            Ranks = new string[] {"4th Officer","3rd Officer","2nd Officer","1st Officer","Captain"};
        }
    }
}
