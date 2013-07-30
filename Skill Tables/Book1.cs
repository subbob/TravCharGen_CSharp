using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class Book1 : cTableMatrix
    {
        // Public Properties

        // Private Properties
        public static List<string> SkillTableIDs = new List<string> {"PDT","SST","AET","AET 2"};

        public string[] ValidTables(cPlayer PC)
        {
            int EDU = PC.Stats.EDU();
            if (EDU < 8)
            {
                List<string> Shortlist = new List<string> {"PDT","SST","AET"};
                return Shortlist.ToArray();
                //return SkillTables[0..2];
            }
            else
            {
                return SkillTableIDs.ToArray();
            }
        }

        private string PadSpaceLeft(string txt)
        {
            return txt.PadRight(15 - txt.Length);
        }
        // Public Methods
        public string TablesAsText (cPlayer PC)
        {
            string Service = PC.Service;
            int EDU = PC.Stats.EDU();
            string rStr = "\n";               // rStr used to build the return value

            for (int i = 0; i <= 6; i++)
            {
                foreach (string TableID in SkillTableIDs)               
                {
                    if (i == 0)
                    {
                        if ((TableID != "AET 2") || (EDU >= 8))
                        {
                            rStr = rStr + PadSpaceLeft(TableID) + "\t";
                        }
                    }
                    else
                    {
                        if ((TableID != "AET 2") || (EDU >= 8))
                        {
                            rStr = rStr + PadSpaceLeft(GetSkill(i, TableID, PC.Service)) + "\t";
                        }
                    }
                }
                rStr = rStr + "\n";
            }
            
            return rStr;
        }
        // Private Methods
        private void LoadSkills()
        {
            Add("+1 STR", 1, "PDT", "Navy"); Add("+1 STR", 1, "PDT", "Marines"); Add("+1 STR", 1, "PDT", "Army"); Add("+1 STR", 1, "PDT", "Scouts"); Add("+1 STR", 1, "PDT", "Merchants"); Add("+1 STR", 1, "PDT", "Other");
            Add("+1 DEX", 2, "PDT", "Navy"); Add("+1 DEX", 2, "PDT", "Marines"); Add("+1 DEX", 2, "PDT", "Army"); Add("+1 DEX", 2, "PDT", "Scouts"); Add("+1 DEX", 2, "PDT", "Merchants"); Add("+1 DEX", 2, "PDT", "Other");
            Add("+1 END", 3, "PDT", "Navy"); Add("+1 END", 3, "PDT", "Marines"); Add("+1 END", 3, "PDT", "Army"); Add("+1 END", 3, "PDT", "Scouts"); Add("+1 END", 3, "PDT", "Merchants"); Add("+1 END", 3, "PDT", "Other");
            Add("+1 INT", 4, "PDT", "Navy"); Add("Gambling", 4, "PDT", "Marines"); Add("Gambling", 4, "PDT", "Army"); Add("+1 INT", 4, "PDT", "Scouts"); Add("+1 STR", 4, "PDT", "Merchants"); Add("Blade Combat", 4, "PDT", "Other");
            Add("+1 EDU", 5, "PDT", "Navy"); Add("Brawling", 5, "PDT", "Marines"); Add("+1 EDU", 5, "PDT", "Army"); Add("+1 EDU", 5, "PDT", "Scouts"); Add("Blade Combat", 5, "PDT", "Merchants"); Add("Brawling", 5, "PDT", "Other");
            Add("+1 SOC", 6, "PDT", "Navy"); Add("Blade Combat", 6, "PDT", "Marines"); Add("Brawling", 6, "PDT", "Army"); Add("Gun Combat", 6, "PDT", "Scouts"); Add("Gun Combat", 6, "PDT", "Merchants"); Add("-1 SOC", 6, "PDT", "Other");
            Add("Ship's Boat", 1, "SST", "Navy"); Add("Vehicle", 1, "SST", "Marines"); Add("Vehicle", 1, "SST", "Army"); Add("Vehicle", 1, "SST", "Scouts"); Add("Vehicle", 1, "SST", "Merchants"); Add("Vehicle", 1, "SST", "Other");
            Add("Vacc Suit", 2, "SST", "Navy"); Add("Vacc Suit", 2, "SST", "Marines"); Add("Air/Raft", 2, "SST", "Army"); Add("Vacc Suit", 2, "SST", "Scouts"); Add("Vacc Suit", 2, "SST", "Merchants"); Add("Gambling", 2, "SST", "Other");
            Add("Fwd Obs", 3, "SST", "Navy"); Add("Blade Combat", 3, "SST", "Marines"); Add("Gun Combat", 3, "SST", "Army"); Add("Mechanical", 3, "SST", "Scouts"); Add("Jack-o-T", 3, "SST", "Merchants"); Add("Brawling", 3, "SST", "Other");
            Add("Gunnery", 4, "SST", "Navy"); Add("Gun Combat", 4, "SST", "Marines"); Add("Fwd Obs", 4, "SST", "Army"); Add("Navigation", 4, "SST", "Scouts"); Add("Steward", 4, "SST", "Merchants"); Add("Bribery", 4, "SST", "Other");
            Add("Blade Combat", 5, "SST", "Navy"); Add("Blade Combat", 5, "SST", "Marines"); Add("Blade Combat", 5, "SST", "Army"); Add("Electronic", 5, "SST", "Scouts"); Add("Electronic", 5, "SST", "Merchants"); Add("Blade Combat", 5, "SST", "Other");
            Add("Gun Combat", 6, "SST", "Navy"); Add("Gun Combat", 6, "SST", "Marines"); Add("Gun Combat", 6, "SST", "Army"); Add("Jack-o-T", 6, "SST", "Scouts"); Add("Gun Combat", 6, "SST", "Merchants"); Add("Gun Combat", 6, "SST", "Other");
            Add("Vacc Suit", 1, "AET", "Navy"); Add("Vehicle", 1, "AET", "Marines"); Add("Vehicle", 1, "AET", "Army"); Add("Vehicle", 1, "AET", "Scouts"); Add("Streetwise", 1, "AET", "Merchants"); Add("Streetwise", 1, "AET", "Other");
            Add("Mechanical", 2, "AET", "Navy"); Add("Mechanical", 2, "AET", "Marines"); Add("Mechanical", 2, "AET", "Army"); Add("Mechanical", 2, "AET", "Scouts"); Add("Mechanical", 2, "AET", "Merchants"); Add("Mechanical", 2, "AET", "Other");
            Add("Electronic", 3, "AET", "Navy"); Add("Electronic", 3, "AET", "Marines"); Add("Electronic", 3, "AET", "Army"); Add("Electronic", 3, "AET", "Scouts"); Add("Electronic", 3, "AET", "Merchants"); Add("Electronic", 3, "AET", "Other");
            Add("Engineering", 4, "AET", "Navy"); Add("Tactics", 4, "AET", "Marines"); Add("Tactics", 4, "AET", "Army"); Add("Jack-o-T", 4, "AET", "Scouts"); Add("Navigation", 4, "AET", "Merchants"); Add("Gambling", 4, "AET", "Other");
            Add("Gunnery", 5, "AET", "Navy"); Add("Blade Combat", 5, "AET", "Marines"); Add("Blade Combat", 5, "AET", "Army"); Add("Gunnery", 5, "AET", "Scouts"); Add("Gunnery", 5, "AET", "Merchants"); Add("Brawling", 5, "AET", "Other");
            Add("Jack-o-T", 6, "AET", "Navy"); Add("Gun Combat", 6, "AET", "Marines"); Add("Gun Combat", 6, "AET", "Army"); Add("Medical", 6, "AET", "Scouts"); Add("Medical", 6, "AET", "Merchants"); Add("Forgery", 6, "AET", "Other");
            Add("Medical", 1, "AET 2", "Navy"); Add("Medical", 1, "AET 2", "Marines"); Add("Medical", 1, "AET 2", "Army"); Add("Medical", 1, "AET 2", "Scouts"); Add("Medical", 1, "AET 2", "Merchants"); Add("Medical", 1, "AET 2", "Other");
            Add("Navigation", 2, "AET 2", "Navy"); Add("Tactics", 2, "AET 2", "Marines"); Add("Tactics", 2, "AET 2", "Army"); Add("Navigation", 2, "AET 2", "Scouts"); Add("Navigation", 2, "AET 2", "Merchants"); Add("Forgery", 2, "AET 2", "Other");
            Add("Engineering", 3, "AET 2", "Navy"); Add("Tactics", 3, "AET 2", "Marines"); Add("Tactics", 3, "AET 2", "Army"); Add("Engineering", 3, "AET 2", "Scouts"); Add("Engineering", 3, "AET 2", "Merchants"); Add("Electronic", 3, "AET 2", "Other");
            Add("Computer", 4, "AET 2", "Navy"); Add("Computer", 4, "AET 2", "Marines"); Add("Computer", 4, "AET 2", "Army"); Add("Computer", 4, "AET 2", "Scouts"); Add("Computer", 4, "AET 2", "Merchants"); Add("Computer", 4, "AET 2", "Other");
            Add("Pilot", 5, "AET 2", "Navy"); Add("Leader", 5, "AET 2", "Marines"); Add("Leader", 5, "AET 2", "Army"); Add("Pilot", 5, "AET 2", "Scouts"); Add("Pilot", 5, "AET 2", "Merchants"); Add("Streetwise", 5, "AET 2", "Other");
            Add("Admin", 6, "AET 2", "Navy"); Add("Admin", 6, "AET 2", "Marines"); Add("Admin", 6, "AET 2", "Army"); Add("Jack-o-T", 6, "AET 2", "Scouts"); Add("Admin", 6, "AET 2", "Merchants"); Add("Jack-o-T", 6, "AET 2", "Other");


        }
        // Default Constructor
        public Book1()
        {
            LoadSkills();
        }
    }
}
