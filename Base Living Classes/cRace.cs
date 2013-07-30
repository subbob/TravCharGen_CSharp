using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cRace
    {
        //protected cStatNames StatNames = new cStatNames();
        public string Name;
        public string Description;

        protected Dictionary<string, cStatLimits> RacialLimits = new Dictionary<string, cStatLimits> { };

        protected void AddMinMax(string arg_StatName, int arg_Min, int arg_Max)
        {
            cStatLimits temp = new cStatLimits();
            temp.MAX = arg_Max;
            temp.MIN = arg_Min;
            RacialLimits.Add(arg_StatName, temp);
        }

        protected void SetDefaults()
        {
            foreach (string StatName in Globals.StatNames)
            {
                AddMinMax(StatName, cStat.MIN_Default, cStat.MAX_Default);
            }
        }

        protected cRace(string arg_Name, string arg_Description = "None")
        {
            Name = arg_Name;
            Description = arg_Description;
        }
    }
}
