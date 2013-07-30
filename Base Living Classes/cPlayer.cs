using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cPlayer : LivingThing
    {
        private Book1 SkillTable = new Book1();
        public cRace Race;
        public string FirstName = "TBD";
        public string LastName = "TBD";
        public string DesiredService = "TBD";
        public string Service = "TBD";
        public int Age = 18;
        public int Wealth = 0;

        private cGender Sex;

        public string Gender()
        {
            return Sex.Gender();
        }

        public int Book1Rank = 0;

        public int Terms = 0;
        public bool Enlisted = false;
        public bool Drafted = false;

        public bool StillServing = false;

        public bool AttendedCollege = false;
        public bool CollegeGrad = false;
        public bool HonorsGrad = false;

        public SkillsDictionary Skills = new SkillsDictionary();

        public List<string> StatSkills = new List<string> { };

        private int SkillRolls = 0;
        private int TotalSkillRolls = 0;

        private void SelectService()
        {
            if (Globals.FullAutoMode)
            {
                Service = ServicesData.Draft();
            }
            else
            {
                MyLib.TextMenu ServiceSelection = new MyLib.TextMenu();
                ServiceSelection.ShowMenu("Choose your service: ", Globals.ServiceNames.ToArray(), Globals.FullManualMode);
                DesiredService = ServiceSelection.Choice;
                Enlist(DesiredService);
            }
            StillServing = true;
            Terms++;
            SkillRolls++;
        }

        public string GetRankText()
        {
            return Globals.PriorServiceTable.RankAsText(this);
        }

        private void Enlist(string TargetService)
        {
            if (Globals.PriorServiceTable.Enlist(this,DesiredService))
            {
                Enlisted = true;
                Service = DesiredService;
            }
            else
            {
                Service = ServicesData.Draft();
            }
        }

        private void ChooseSkillTable()
        {
            MyLib.TextMenu TableSelection = new MyLib.TextMenu();
            List<string> SkillTables = new List<string> { };
            string NewSkill;
            // Temporary output to show skill tables
            if (Globals.FullManualMode)
            {
                Console.WriteLine(SkillTable.TablesAsText(this));
            }
            TableSelection.ShowMenu("Choose your skill table: ", SkillTable.ValidTables(this), Globals.FullManualMode);
            NewSkill = SkillTable.GetSkill(Globals.Random.RollDie(6), TableSelection.Choice, Service);
            ProcessSkill(NewSkill);
        }

        private void ProcessSkill(string arg_Skill)
        {
            if (arg_Skill.Substring(0, 2) == "+1")
            {
                Globals.Verbose("Skill Gained: " + arg_Skill,true);
                Globals.Display("\n\t\t** Skill Gained: " + arg_Skill + " **\n");
                string StatModified = arg_Skill.Substring(3, 3);
                Stats.Increment(StatModified);
                StatSkills.Add(arg_Skill);
            }
            else if (arg_Skill.Substring(0, 2) == "-1")
            {
                Globals.Verbose("Skill Gained: " + arg_Skill, true);
                Globals.Display("\n\t\t** Skill Gained: " + arg_Skill + " **\n");
                string StatModified = arg_Skill.Substring(3, 3);
                Stats.Decrement(StatModified);
                StatSkills.Add(arg_Skill);
            }
            else
            {
                Globals.Verbose("Skill Gained: " + arg_Skill, true);
                Globals.Display("\n\t\t** Skill Gained: " + arg_Skill + " **\n");
                Skills.Gain(arg_Skill);
            }
        }

        private void ResolveCareer()
        {
            // Stub
            Globals.Verbose("Entered ResolveCareer", true);
            while (IsAlive && StillServing)
            {
                // Stub
                Globals.Verbose("Resolving Terms", true);
                Age += 4;
                ResolveTerm();
            }

        }

        private void CheckCommissioned()
        {
            // Check for Commissioning
            if (Book1Rank == 0)
            {
                Globals.Verbose("Calling Commissioned", true);
                if (Globals.PriorServiceTable.Commissioned(this))
                {
                    Globals.Verbose("Commissioned", true);
                    Globals.Display("Commissioned");
                    Book1Rank++;
                    SkillRolls++;
                }
            }        
        }

        private void CheckPromoted()
        {
            // Check for Promotion
            if (Book1Rank > 0 && Book1Rank < 6)
            {
                Globals.Verbose("Calling Promoted", true);
                if (Globals.PriorServiceTable.Promoted(this))
                {
                    Globals.Verbose("Promoted", true);
                    Globals.Display("Promoted");
                    Book1Rank++;
                    SkillRolls++;
                }
            }
        }

        private void DetermineSkills()
        {
            // Determine Skills
            Globals.Verbose("\t\t** Determining " + SkillRolls + " skills earned **", true);
            //Globals.Display("\t\t**Determining " + SkillRolls + " skills earned **");
            TotalSkillRolls += SkillRolls;
            for (int i = 1; i <= SkillRolls; i++)
            {
                Globals.Display("\t\t** Determining " + i + " of " + SkillRolls + " Skills **");
                ChooseSkillTable();
            }        
        }

        private void CheckReenlistment()
        {
            // Check For Reenlistment
            Globals.Verbose("Calling Reenlisted", true);
            if (Globals.PriorServiceTable.Reenlisted(this))
            {
                Globals.Verbose("Reenlisted successfully", true);
                Globals.Display("Reenlisted successfully");
                Terms++;
                SkillRolls = 0;
            }
            else
            {
                Globals.Verbose("Failed to reenlist", true);
                Globals.Display("Failed to reenlist");
                StillServing = false;
            }        
        }

        private void ResolveTerm()
        {
            Globals.Verbose(Stats.AsText(), true);
 
            Globals.Verbose(PrintSkills(), true);
 
            
            // Check for Survival
            Globals.Verbose("Resolving Term # " + Terms, true);
            Globals.Display("\nResolving Term # " + Terms + "\n");
            Globals.Display("Current status:\n\n" + Stats.AsText() + "\n" + PrintSkills());
            Globals.Verbose("Calling Survived", true);
            if (Globals.PriorServiceTable.Survived(this))
            {
                SkillRolls++;       // Earn 1 skill per term

                Globals.Verbose("Survived", true);
                Globals.Display("Survived");
                CheckCommissioned();
                
                CheckPromoted();

                DetermineSkills();

                CheckReenlistment();
            }
            else
            {
                // Stub - write event for now
                Globals.Verbose("Died during Term " + Terms, true);
                Globals.Display("Died during Term " + Terms);
                IsAlive = false;
            }
        }

        private int MusterRolls()
        {
            return Terms + Book1Rank;
        }
        
        private void MusterOut()
        {
            // Stub
            Globals.Verbose("Mustering Out with " + MusterRolls() + " benefit rolls", true);
            Globals.Verbose("Total Skill Rolls: " + TotalSkillRolls, true);
        }

        public void ReRollScores()
        {
            Stats.NewScores();
        }

        private void SetName(bool ForceAuto = false)
        {
            if (Globals.FullAutoMode || ForceAuto)
            {
                // Hard code race for now
                if (Sex.Gender() == "Male")
                {
                    FirstName = Globals.Pick(Globals.Male);
                }
                else
                {
                    FirstName = Globals.Pick(Globals.Female);
                }
                LastName = Globals.Pick(Globals.Last);
            }
            else
            {

                Console.Write("Character's first name? (Blank for random) >> ");
                FirstName = Console.ReadLine();
                if (FirstName != "")
                {
                    Console.Write("Character's last name? >> ");
                    LastName = Console.ReadLine();
                }
                else
                {
                    SetName(true);
                }
            }            
        }

        public string PrintSkills()
        {
            string result = "";
            foreach (Skill ThisSkill in Skills.SkillsKnown())
            {
                result = result + ThisSkill.AsText() + "\n";
            }
            return result;
        }

        public string PrintStatSkills()
        {
            string result = "";
            foreach (string ThisSkill in StatSkills)
            {
                result = result + ThisSkill + "\n";
            }
            return result;
        }

        private void SetRace()
        {
            Globals.Verbose("Default Race: Human", true);
            Race = new Human();
        }

        private void SetGender()
        {
            MyLib.TextMenu GenderMenu = new MyLib.TextMenu();
            GenderMenu.ShowMenu("Gender? >> ", cGender.Genders.ToArray(), Globals.FullManualMode);

            if (GenderMenu.Choice == "Male")
            {
                Sex = new cMale("Male");
            }
            else if (GenderMenu.Choice == "Female")
            {
                Sex = new cFemale("Female");
            }
            else
            {
                Globals.Verbose("Error in Choose Gender", true);
            }
        }

        private void SetScores()
        {
            Stats.NewScores();
            Globals.Verbose(Stats.AsText(), true);
        }

        public string NameAsText()
        {
            return "Name: " + FirstName + " " + LastName;
        }

        public string RankAsText()
        {
            return "Rank: " + GetRankText() + " (" + Book1Rank + ")";
        }

        public string GenderAsText()
        {
            return "Gender: " + Sex.Gender();
        }

        public string PrintChar()
        {
            string result = "";

            result = result + NameAsText() + "  " + "UPP: " + Stats.AsFullUPP() + "  " + GenderAsText() + "\n";

            if (Drafted)
            {
                result = result + "Failed to enlist in " + DesiredService + "  " + "Drafted into " + Service + "\n";
            }
            result = result + "Service: " + Service;

            result = result + " (" + Terms + " Terms)" + "  " + "Age: " + Age + "  ";

            if (Book1Rank > 0)
            {
                result = result + "Rank: " + GetRankText() + " (" + Book1Rank + ")" + "\n\n";
            }
            else
            {
                result = result + "Rank: Enlisted" + "\n\n";
            }

            result = result + "Stats:" + "\n\n" + Stats.AsTextWithUPP() + "\n";

            if (StatSkills.Count > 0)
            {
                result = result + "Stat Mods (" + StatSkills.Count + "): " + "\n\n" + PrintStatSkills() + "\n";
            }

            result = result + "Skills (" + (TotalSkillRolls - StatSkills.Count) + " rolls):" + "\n\n" + PrintSkills() + "\n";

            if (!IsAlive)
            {
                result = result + "(DEAD/INJURED) ";
            }
            result = result + "Mustering out benefits:" + "\n\n" + MusterRolls() + " Rolls" + "\n\n";
            return result;
        }

        private void ResetSkills()
        {
            foreach (Skill ThisSkill in Skills.SkillsKnown())
            {
                ThisSkill.Reset();
            }
            Skills_DB.ZeroSkills();
        }

        public cPlayer()
        {
            CreateNewPC();
        }

        private void CreateNewPC()
        {
            ResetSkills();
            SetGender();
            SetName();
            SetRace();
            SetScores();
            SelectService();
            ResolveCareer();
            MusterOut();
        }
    }
}
