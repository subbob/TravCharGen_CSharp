using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class OtherServiceData : cServiceData
    {

        public OtherServiceData()
        {
            Enlistment.Target = 3;
            //Enlistment.Add_Mod(1, "INT", 8);
            //Enlistment.Add_Mod(2, "EDU", 9);

            Survival.Target = 5;
            Survival.Add_Mod(2, "INT", 9);

            Commission.Target = 13;
            //Commission.Add_Mod(1, "SOC", 9);

            Promotion.Target = 13;
            //Promotion.Add_Mod(1, "EDU", 8);

            Reenlist.Target = 5;

            OfficerCorps = false;

            Ranks = new string[] { "--", "--", "--", "--", "--", "--" };
        }
    }
}
