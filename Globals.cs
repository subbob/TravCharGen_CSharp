using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Traveller_Book1
{
    public static class Globals
    {
        
        public static List<string> Male =  new List<string> {"Arthul","Wardy","Heward","Jonio","Asond","Gery","Martor","Carlie","Jerry","Chrankenn","Keve","Phury","Stery","Markeith","Jose","Chone","Johnio","Johnne","Vidy","Credy","Jackenn","Bremy","Billie","Jery","Andymo","Bobby","Waynio","Patry","Berteph","Geny","Arlor","Kenny","Lase","Remy","Aarrymo","Willie","Done","Chewalt","Jackev","Arohn","Keithy","Steve","Esseph","Jase","Brusse","Cotter","Mase","Atther","Gene","Johne","Peton","Rence","Harry","Jeffry","Jone","Markev","Riane","Brone","Naldy","Sterry","Artis","Victev","Tine","Dany","Terry","Clary","Ernew","Philie","Raymy","Aryne","Sonio","George","Denny","Damy","Showard","Rony","Hewalt","Rewalt","Cliamy","Sone","Ever","Andreth","Enjan","Reward"};
        public static List<string> Female =  new List<string> {"Andann","Lynie","Dora","Bine","Mely","Aryn","Hera","Cesa","Joanie","Bara","Sanie","Aron","Jane","Anned","Bora","Alis","Tine","Katha","Roley","Donnie","Deby","Joyca","Maria","Jana","Dithy","Caria","Even","Stera","Ettyn","Jule","Nica","Mary","Judy","Fricy","July","Nicia","Debra","Michy","Tephia","Tina","Mara","Manda","Kelly","Kathria","Juda","Amyl","Patra","Doria","Pama","Dithia","Heria","Cathy","Diane","Saria","Karea","Athleet","Eryn","Marthy","Mildra","Chresa","Sary","Pamy","Lyne","Anis","Achel","Chrone","Dorea","Rese","Chrahy","Reda","Kara","Kimby","Donna","Debri","Melie","Eris","Aber","Chrenda","Joana"};
        public static List<string> Last =  new List<string> {"Cooper","Baily","Coly","Hardson","Johnson","Patte","Jackson","Lory","Lery","Andes","Murphy","Amins","Pery","Baker","Teray","Thompson","Turnes","Homorg","Cotte","Coxand","Belley","Sanchy","Meson","Bertson","Bailey","Harre","Liamson","Jacksand","Reediaz","Colly","Whilley","Millee","Sonez","Reenez","Hughy","Aller","Jamir","Smorry","Pezal","Yournes","Rosson","Willey","Thughy","Cooker","Mithy","Brogonz","Homan","Carte","Washy","Perray","Rivis","Binson","Halley","Powalk","Scarte","Brogan","Grodre","Linson","Philly","Wooders","Butlee","Ashis","Jamith","Marte","Richy","Scoxand","Wricia","Tonez","Rownand","Terson","Taylee","Aler","Warte","Righte","Manett","Yougher","Youssett","Floperr","Manes","Dersell","Helly","Leson","Morguez","Peray","Lemart","Flenett","Ackson","Coopatt","Howell","Hilly","Ersod","Riffost","Hompson","Ampbez","Belly","Reson","Colley","Grison","Rezal","Bellee","Sterson","Sonand","Herner","Jonett","Tinand","Alers","Mitchy","Selly","Riffin","Ricia","Wardsanch","Lemoor","Grisell","Hite","Jones","Colee","Campbell","Andez","Rookson","Welly","Ander","Barnand","Walker","Lener","Sonels","Tere","Jenkell","Campberts","Jaman","Cliamson","Wardez","Howards","Keray","Erson","Jenking","Clere","Artis","Smanez","Robarn","Longan","Brichy","Ramurph","Hendams","Morray","Rison","Gerson","Rogonz","Grezal","Bennett","Whomart","Ramart","Arris","Wison","Barnett","Grosson","Resand","Benner","Hingte","Lemons","Kere"};

        public static bool VerboseMode = false;

        public static bool FileOutputMode = true;

        public static string OutputFileName = "TravCharGen.txt";

        public static void ToggleVerbose()
        {
            VerboseMode = !VerboseMode;
        }

        public static string Pick(List<string> arg_StrList)
        {
            return arg_StrList.ToArray()[Random.RollDie(arg_StrList.Count() - 1)];
        }

        public static ServicesData PriorServiceTable = new ServicesData();
        public static bool FullManualMode = false;
        public static bool FullAutoMode = true;

        public static void Display(string msg)
        {
            if (FullManualMode)
            {
                Console.WriteLine(msg);
            }
        }

        public static void Verbose(string msg,bool NewLine = false)
        {
            if (VerboseMode)
            {
                Console.Write(msg);
                if (NewLine)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(" | ");
                }
                if (FileOutputMode)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Globals.OutputFileName, true))
                    {
                        file.Write(msg);
                    }
                    if (NewLine)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Globals.OutputFileName, true))
                        {
                            file.WriteLine();
                        }
                    }
                    else
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Globals.OutputFileName, true))
                        {
                            file.Write(" | ");
                        }
                    }                    
                }

            }
        }

        public static void ToggleMode()
        {
            if (FullManualMode)
            {
                FullAutoMode = !FullAutoMode;
                FullManualMode = !FullManualMode;
            }
        }

        public static List<string> ServiceNames = new List<string> {"Navy","Marines","Army","Scouts","Merchants","Other"};
        public static List<string> StatNames = new List<string> { "STR", "DEX", "END", "INT", "EDU", "SOC" };
        public static MyLib.Dice Random = new MyLib.Dice();


        // Can't think of where to put this right now. Will figure it out later.
        // Probably in a future ResolveNewSkill class

        public static bool IsStatMod(string arg_SkillName)
        {
            return ((arg_SkillName.Substring(0, 1) == "+") ||
                    (arg_SkillName.Substring(0, 1) == "-"));

        }
    }
}
