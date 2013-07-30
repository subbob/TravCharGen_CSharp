using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class LivingThing
    {
        protected string Name;
        protected string Description;
        public Attributes Stats;

        public Attributes CurrentStats;

        public bool IsAlive;

        public LivingThing()
        {
            Stats = new Attributes();
            CurrentStats = new Attributes();
            CurrentStats = Stats;
            IsAlive = true;
            Name = "";
            Description = "";
        }
    }
}
