using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLib
{
    public class TextMenu
    {
        static public string MenuMode = "Manual";
        string[] MenuItems;
        public string Choice;

        public string GetMode()
        {
            return MenuMode;
        }

        public void ChangeMode()
        {
            if (MenuMode == "Manual")
            {
                MenuMode = "Auto";
            }
            else
            {
                MenuMode = "Manual";
            }
        }
        
        private bool IsNumber(string txt)
        {
            List<string> Numbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            if (Numbers.Contains(txt))
            {
                return true;
            }
            else
	        {
                return false;
	        }
        }

        private string GetChoice(string Prompt)
        {
            string UserInput = "";
            int ctr = 0;
            bool InvalidInput = true;
            int UserChoice = 0;
            bool InvalidNumber = true;
            while (InvalidInput)
            {
                ctr = 0;
                foreach (string Item in MenuItems)
                {
                    ctr++;
                    Console.WriteLine("\t" + ctr + ":  " + Item);
                }

                Console.Write("\t" + Prompt + " >> ");

                UserInput = Console.ReadLine();

                if (UserInput.Length == 1)
                {
                    if (IsNumber(UserInput))
                    {
                        InvalidNumber = false;
                    }
                }

                if (UserInput == "" || InvalidNumber)
                {
                    Console.WriteLine("Invalid option.");
                }
                else
                {
                    UserChoice = System.Convert.ToInt32(UserInput);                    
                    if (UserChoice < 1 || UserChoice > MenuItems.Length)
                    {
                        Console.WriteLine("Invalid option.");
                    }
                    else
                    {
                        InvalidInput = false;
                    }
                }
            }

            return MenuItems[UserChoice - 1];
        }

        public void ShowMenu(string Prompt, string[] Choices, bool ManualMode = true)
        {
            MenuItems = Choices;
            if (ManualMode)
            {
                Choice = GetChoice(Prompt);
            }
            else
            {
                MyLib.Dice RandomChoice = new MyLib.Dice();
                Choice = Choices[RandomChoice.RollDie(Choices.Count())-1];
            }
        }

        public TextMenu()
        {
            // Do nothing
        }

        public void Pause()
        {
            string Dummy = "";
            Console.Write("Press Enter to continue...");
            Dummy = Console.ReadLine();
        }	
    }

}
