using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cRollCheck : cBaseCheck
    {
        // Public Properties

        // Private Properties

        // Public Methods
        public bool Success(cPlayer PC,bool ReenlistCheck = false)
        {
            int DieRoll = Globals.Random.RollDice(2, 6);
            int TotalMods = Total_DM(PC);
            string msg;

            if ((DieRoll + TotalMods) >= Target)
            {
                if (PC.Terms >= 7 && ReenlistCheck)
                {
                    msg = "High Year Tenure reenlistment check. ";
                    if (DieRoll == 12)
                    {
                        msg = "Success: Rolled a 12";
                        Globals.Verbose(msg);
                        return true;
                    }
                    else
                    {
                        msg = "Forced out, rolled a " + DieRoll;
                        Globals.Verbose(msg);
                        return false;
                    }
                }
                else
                {
                    msg = "cRollCheck - Success: " + DieRoll + " + " + TotalMods + " >= " + Target;
                    Globals.Verbose(msg);
                    return true;
                }
            }
            else
            {
                msg = "cRollCheck - Failure: " + DieRoll + " + " + TotalMods + " < " + Target;
                Globals.Verbose(msg);
                return false;
            }
        }
        // Private Methods


    }
}
