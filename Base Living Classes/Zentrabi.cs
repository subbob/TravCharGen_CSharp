using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class Zentrabi : cRace
    {

        protected void SetZentrabiDefaults()
        {
            foreach (string StatName in Globals.StatNames)
            {
                if (StatName == "STR")
                {
                    AddMinMax(StatName, 1, 12);
                }
                else if (StatName == "DEX")
                {
                    AddMinMax(StatName, 4, 17);
                }
                else
                {
                    AddMinMax(StatName, cStat.MIN_Default, cStat.MAX_Default);
                }
            }
        }

        public Zentrabi() : base("Zentrabi", "Evolved on a low gravity world resulted in lower strength, but higher dexterity")
        {
            SetZentrabiDefaults();
        }

    }
}
