using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class Attributes
    {
        public Dictionary<string, cStat> Scores = new Dictionary<string, cStat> { };        
        //public Hashtable Scores = new Hashtable();
        //private cStatNames StatNames = new cStatNames();

        public void Decrement(string arg_StatName)
        {
            Scores[arg_StatName].Value--;
        }

        public void Increment(string arg_StatName)
        {
            Scores[arg_StatName].Value++;
        }


        public int GetStat(string arg_StatName)
        {
            return Value(arg_StatName);
        }

        public int DEX()
        {
            return Value("DEX");
        }

        public int STR()
        {
            return Value("STR");
        }

        public int END()
        {
            return Value("END");
        }

        public int INT()
        {
            return Value("INT");
        }

        public int EDU()
        {
            return Value("EDU");
        }

        public int SOC()
        {
            return Value("SOC");
        }

        public int Total()
        {
            int sum = 0;
            for (int i = 0; i < Globals.StatNames.Count(); i++)
            {
                sum += Value(Globals.StatNames[i]);
            }
            return sum;
        }

        public double Average()
        {
            return Total() / 6.0;
        }

        //public int Total()
        //{
        //    return (this.STR() + this.DEX() + this.END() + this.INT() + this.EDU() + this.SOC());
        //}

        //public int Average()
        //{
        //    return ((int)( (STR() + DEX() + END() + INT() + EDU() + SOC() ) / 6.0));
        //}

        private int Value(string arg_Name)
        {
            cStat temp;
            temp = (cStat)Scores[arg_Name];
            return temp.Value;
        }

        public void NewScores()
        {
            MyLib.Dice GenScores = new MyLib.Dice();

            for (int i = 0; i < Globals.StatNames.Count; i++)
            {
                cStat temp;
                temp = new cStat();
                temp.Set(Globals.StatNames[i], GenScores.RollDice(2, 6));
                Scores[Globals.StatNames[i]] = temp;
            }
        }

        public string AsText()
        {
            cStat ThisStat;
            string temp = "";
            for (int i = 0; i < Globals.StatNames.Count; i++)
            {
                ThisStat = (cStat)Scores[Globals.StatNames[i]];
                temp = temp + ThisStat.AsText() + "\n"; 
            }
            return temp;
        }
        public string AsFullUPP()
        {
            cStat ThisStat;
            string temp = "";
            for (int i = 0; i < Globals.StatNames.Count; i++)
            {
                ThisStat = (cStat)Scores[Globals.StatNames[i]];
                temp = temp + ThisStat.ToHex();
            }
            return temp;
        }

        public string AsUPP()
        {
            cStat ThisStat;
            string temp = "";
            for (int i = 0; i < Globals.StatNames.Count; i++)
            {
                ThisStat = (cStat)Scores[Globals.StatNames[i]];
                temp = temp + ThisStat.AsUPP();
            }
            return temp;
        }

        public string AsTextWithUPP()
        {
            cStat ThisStat;
            string temp = "";
            for (int i = 0; i < Globals.StatNames.Count; i++)
            {
                ThisStat = (cStat)Scores[Globals.StatNames[i]];
                temp = temp + ThisStat.AsTextWithUPP() + "\n";
            }
            return temp;
        }

        public Attributes()
        {
            NewScores();
        }
    }
}
