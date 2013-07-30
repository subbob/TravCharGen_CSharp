using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cDM
    {
        int DM;
        string Stat;
        int Target;
        bool SkillCheck;

        public int Value(cPlayer PC)
        {
            int BaseStat;

            if (SkillCheck)
            {  
                BaseStat = PC.Skills[Stat].GetValue();
                Globals.Verbose("cDM - SkillCheck - BaseStat: " + BaseStat);
            }
            else
            {
                BaseStat = PC.Stats.GetStat(Stat);
                Globals.Verbose("cDM - StatCheck - BaseStat: " + BaseStat);
            }

            if (BaseStat >= Target)
            {
                Globals.Verbose(BaseStat + " >= " + Target + "  Returning DM: " + DM);
                return DM;
            }
            else
            {
                Globals.Verbose(BaseStat + " < " + Target + "  Returning DM: " + 0);
                return 0;
            }
        }

        public cDM(int arg_DM, string arg_Stat, int arg_Target, bool arg_SkillCheck = false)
        {
            string msg = "";
            msg = "+" + arg_DM + " if " + arg_Stat + " >= " + arg_Target;
            if (SkillCheck)
            {
                msg = "Creating SkillCheck cDM. " + msg;
            }
            else
            {
                msg = "Creating StatCheck cDM. " + msg;
            }
            Globals.Verbose(msg, true);
            DM = arg_DM;
            Stat = arg_Stat;
            Target = arg_Target;
            SkillCheck = arg_SkillCheck;
        }
    }
}
