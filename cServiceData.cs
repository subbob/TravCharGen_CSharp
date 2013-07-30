using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cServiceData
    {
        // Public Properties

        protected cRollCheck Enlistment = new cRollCheck();

        protected cRollCheck Survival = new cRollCheck();

        protected cRollCheck Commission = new cRollCheck();

        protected cRollCheck Promotion = new cRollCheck();

        protected cRollCheck Reenlist = new cRollCheck();

        public string[] Ranks;

        protected bool OfficerCorps;

        public bool Enlist(cPlayer PC)
        {
            return Enlistment.Success(PC);
        }

        public bool Survived(cPlayer PC)
        {
            return Survival.Success(PC);
        }
        public bool Commissioned(cPlayer PC)
        {
            if (OfficerCorps)
            {
                return Commission.Success(PC);
            }
            else
            {
                return false;
            }
        }
        public bool Promoted(cPlayer PC)
        {
            if (OfficerCorps)
            {
                return Promotion.Success(PC);
            }
            else
            {
                return false;
            }            
        }

        public bool Reenlisted(cPlayer PC)
        {
            return Reenlist.Success(PC,true);
        }

        // Private Properties

        // Public Methods

        // Private Methods

        // Default Constructor

    }
}
