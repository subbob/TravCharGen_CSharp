using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class SkillsDictionary : Dictionary<string, Skill>
    {
        public List<Skill> SkillsKnown()
        {
            List<Skill> TempList = new List<Skill> { };

            foreach (KeyValuePair<string, Skill> entry in this)
            {
                TempList.Add(entry.Value);
            }
            return TempList;
        }



        public void Reset(string arg_SkillName)
        {
            if (this.ContainsKey(arg_SkillName))
            {
                this[arg_SkillName].Reset();
            }
        }

        public void Gain(string arg_SkillName)
        {
            if (!this.ContainsKey(arg_SkillName))
            {
                this.Add(arg_SkillName, Skills_DB.LookUp(arg_SkillName));
            }
            this[arg_SkillName].Gain();
        }

    }
}
