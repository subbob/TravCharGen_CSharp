using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class Skills_DB
    {

        //public static Hashtable AllSkills = new Hashtable();
            public static Dictionary<string, Skill> AllSkills = new Dictionary<string, Skill> { };  

            public static List<string> Categories = new List<string> { "Gun Combat", "Vehicle","General", "Melee Combat",
                                                                        "Bow Combat","Science","Academic","Language"};

            static Hashtable SkillGroups = new Hashtable();

            public static void ZeroSkills()
            {
                foreach (Skill Entry in AllSkills.Values)
                {
                    Entry.Reset();

                }
            }

            public void something()
            {
                string[] temp = new string[] { };
                temp = Categories.ToArray();
                
                for (int i=0; i<temp.Count(); i++)
                {
                    Group TempGroup = new Group();
                    SkillGroups[Categories[i]] = TempGroup;
                }
            }

            public static bool Initialized = false;
            //public static string[] Group = new string[] {"Gun Combat","Vehicle","General","Melee Combat"};

            
            public void GetSkillsByCategory (string Key)
            {
                if (AllSkills.ContainsKey(Key))
                {
                    
                }
                else
                {
                    //OutFile.PrintLine("** ERROR ** " + Key + " category not found! **");
                }
            }

            private string[] ThisArray(List<string> SomeList)
            {
                string[] temp = new string[] { };
                temp = SomeList.ToArray();
                return temp;
            }

            private string SelectCascadeSkill(string Key,bool ManualMode = true)
            {
                string[] GroupChoices;
               
                MyLib.TextMenu ThisMenu;
                Group cascade = (Group)SkillGroups[Key];

                if (Categories.Contains(Key))
                {
                    GroupChoices = cascade.ToArray();
                }
                else
                {
                    //OutFile.PrintLine ("** ERROR in SelectCascadeSkill: " + Key + " category not found! **");
                    return ("Invalid Skill");
                }
                ThisMenu = new MyLib.TextMenu();
                ThisMenu.ShowMenu("Select new skill", GroupChoices, Globals.FullManualMode);
                return (ThisMenu.Choice);
            }

            public void Gain(string Key)
            {
                if (Categories.Contains(Key))
                { // Cascade skill
                    LookUp(SelectCascadeSkill(Key)).Gain();
                }
                else
                { // Non-cascaded skill
                    //OutFile.PrintLine("Gaining " + Key);
                    LookUp(Key).Gain();
                }
            }

            private void NewSkill(string Name, string Category)
            {
                Item Test = new Item();
                Test.NewItem(Name);
                if (!SkillGroups.ContainsKey(Category))
                {
                    SkillGroups.Add(Category,new Group());
                }
                Group Temp;
                Temp = (Group)SkillGroups[Category];
                Temp.Add(Category);
            }

            public void LoadSkills_DB()
            {

                NewSkill("Zero-G", "General");
                NewSkill("Watercraft", "Vehicle");
                NewSkill("Vilani", "Language");
                NewSkill("Vehicle Gunnery", "General");
                NewSkill("Vacc Suit", "General");
                NewSkill("Throwing", "Gun Combat");
                NewSkill("Theology", "Science");
                NewSkill("Tactics", "General");
                NewSkill("Survival", "General");
                NewSkill("Survey", "General");
                NewSkill("Streetwise", "General");
                NewSkill("Steward", "General");
                NewSkill("Space Tactics", "General");
                NewSkill("Sophontology", "Science");
                NewSkill("SMG", "Gun Combat");
                NewSkill("Sling", "Bow Combat");
                NewSkill("Shotgun", "Gun Combat");
                NewSkill("Short Blade", "Melee Combat");
                NewSkill("Ships Boat", "General");
                NewSkill("Ship Gunnery", "General");
                NewSkill("Robotics", "Academic");
                NewSkill("Rifle", "Gun Combat");
                NewSkill("Recruiting", "General");
                NewSkill("Recon", "General");
                NewSkill("Psychology", "Science");
                NewSkill("Prospecting", "General");
                NewSkill("Polearms", "Melee Combat");
                NewSkill("Planetology", "Science");
                NewSkill("Pistol", "Gun Combat");
                NewSkill("Pilot", "General");
                NewSkill("Physics", "Science");
                NewSkill("Perform", "General");
                NewSkill("Parapsychology", "Science");
                NewSkill("Navigation", "General");
                NewSkill("Naval Architect", "General");
                NewSkill("Medical", "Academic");
                NewSkill("Mechanical", "General");
                NewSkill("Mechanic", "Academic");
                NewSkill("Long Blade", "Melee Combat");
                NewSkill("Linguistics", "Science");
                NewSkill("Legal", "Academic");
                NewSkill("Leader", "General");
                NewSkill("Laser Weapons", "Gun Combat");
                NewSkill("Journalism", "Science");
                NewSkill("Jack of All Trades", "General");
                NewSkill("Interrogation", "General");
                NewSkill("Instruction", "Academic");
                NewSkill("Hunting", "General");
                NewSkill("High Energy Weapons", "Gun Combat");
                NewSkill("Heavy Weapons", "General");
                NewSkill("Gveh", "Language");
                NewSkill("Ground Vehicle", "Vehicle");
                NewSkill("Gravitics", "General");
                NewSkill("Gravcraft", "Vehicle");
                NewSkill("Geology", "Science");
                NewSkill("Gambling", "General");
                NewSkill("Galanglic", "Language");
                NewSkill("Forward Observer", "General");
                NewSkill("Forgery", "General");
                NewSkill("Forensics", "Science");
                NewSkill("Field Artillery", "General");
                NewSkill("Equestrian", "General");
                NewSkill("Engineering", "Academic");
                NewSkill("Electronics", "Academic");
                NewSkill("Economics", "Science");
                NewSkill("Ecology", "Science");
                NewSkill("Early Firearms", "Gun Combat");
                NewSkill("Demolitions", "General");
                NewSkill("Cudgel", "Melee Combat");
                NewSkill("Crossbow", "Bow Combat");
                NewSkill("Craftsman", "Academic");
                NewSkill("Computer", "Academic");
                NewSkill("Communications", "General");
                NewSkill("Combat Engineering", "General");
                NewSkill("Civil Engineering", "Science");
                NewSkill("Chemistry", "Science");
                NewSkill("Carousing", "General");
                NewSkill("Bribery", "General");
                NewSkill("Brawling", "Melee Combat");
                NewSkill("Bow", "Bow Combat");
                NewSkill("Bola", "Bow Combat");
                NewSkill("Blowgun", "Bow Combat");
                NewSkill("Biology", "Science");
                NewSkill("Battle Dress", "General");
                NewSkill("Astronomy", "General");
                NewSkill("Aslan", "Language");
                NewSkill("Archeology", "Science");
                NewSkill("Animal Handling", "General");
                NewSkill("Air-Cushion Vehicle", "Vehicle");
                NewSkill("Aircraft", "Vehicle");
                NewSkill("Agriculture", "Science");
                NewSkill("Admin", "General");



            }

            public bool SkillChallenge(string Key, int target, string success, string fail)
            {
                
                if (RequiredSkill(Key, target))
                {
                    //OutFile.PrintLine(success);
                    return true;
                }
                else
                {
                    //OutFile.PrintLine(fail);
                    return false;
                }
            }

            public bool RequiredSkill(string Key, int target)
            {
                return (LookUp(Key).GetValue() >= target);
            }

            public static void ResetSkills()
            {
                foreach (Skill Entry in AllSkills.Values)
                {
                    Entry.Reset();
                }
            }

            public static Skill LookUp(string Key)
            {

                Skill temp = new Skill();
                if (!AllSkills.ContainsKey(Key))
                {
                    // Add new skill if not found
                    temp.NewItem(Key);
                    AllSkills[Key] = temp;

                    // Record the addition, could have been a typo
                    //OutFile.PrintLine("** LookUp(" + Key + ") not found. Added " + Key + " as a new skill.");
                }

                return (Skill)AllSkills[Key];
            }

            //public void PrintSkill(Skill ThisSkill)
            //{
            //    ThisSkill.PrintSkill(ThisSkill);
            //}

            public void WriteSkills()
            {
                //OutFile.PrintLine("Current Skills:\n");
                //foreach (DictionaryEntry entry in AllSkills) 
                foreach (Skill entry in AllSkills.Values)
                {
                    //Skill O = new Skill();

                    //O = (Skill)entry.Value;

                    //O.Print();
                    entry.Print();
                }
                //OutFile.PrintLine("\n");
            }

            public Skills_DB()
            {
                if (!Initialized)
                {
                    LoadSkills_DB();
                    Initialized = true;
                }
                else
                {
                }
            }
    }
}
