using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{

    public class Program
    {

        static void Main(string[] args)
        {
            string ExecOption = "AUTO";
            string LogOption = "QUIET";
            string FileName = "TravCharGen.txt";
            bool HelpMode = false;
            
            bool RunMode = false;
            
            int Iterations = 10;
            bool InteractiveMode = true;

            string Generating = "Continue";

            List<cPlayer> NewPCs = new List<cPlayer> { };

            Globals.FileOutputMode = true;

            if (args.Count() > 0)       // Process command line arguments
            {
                bool ValidOptions = true;
                string InvalidOptions = "";
                foreach (string arg in args)
                {
                    string option;
                    string value;
                    
                    if (arg.Substring(0, 1) == "-" && arg.Length >= 2)
                    {
                        option = arg.Substring(1, 1).ToUpper();
                        if (option == "R")
                        {
                            RunMode = true;
                        }
                        else if (option == "H")
                        {
                            DisplayExtendedUsage();
                            RunMode = false;
                            HelpMode = true;
                        }
                        else
                        {
                            if (arg.Length > 3)
                            {
                                int ArgLen = arg.Length;
                                
                                value = arg.Substring(3, arg.Length-3);
                                switch (option)
                                {
                                    case "N":

                                        Iterations = Convert.ToInt32(value);
                                        break;

                                    case "M":
                                        switch (value.ToUpper())
                                        {
                                            case "AUTO":
                                                ExecOption = "AUTO";
                                                break;

                                            case "FULLAUTO":
                                                ExecOption = "FULLAUTO";
                                                break;

                                            case "MANUAL":
                                                ExecOption = "MANUAL";
                                                break;

                                            default:
                                                InvalidOptions = InvalidOptions + arg + " is an invalid option.\n";
                                                ValidOptions = false;
                                                break;
                                        }
                                        break;

                                    case "V":
                                        switch (value)
                                        {
                                            case "QUIET":
                                                LogOption = "QUIET";
                                                break;

                                            case "VERBOSE":
                                                LogOption = "VERBOSE";
                                                break;

                                            default:
                                                InvalidOptions = InvalidOptions + arg + " is an invalid option.\n";
                                                ValidOptions = false;
                                                break;
                                        }
                                        break;

                                    case "O":
                                        switch (value)
                                        {
                                            case "NONE":
                                                Globals.FileOutputMode = false;
                                                break;

                                            default:
                                                Globals.FileOutputMode = true;
                                                FileName = value;
                                                Globals.OutputFileName = FileName;
                                                if (!System.IO.File.Exists(FileName))
                                                {
                                                    // System.IO.File.CreateText(FileName);
                                                }
                                                break;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                InvalidOptions = InvalidOptions + arg + " is an invalid option.\n";
                                ValidOptions = false;
                            }
                        }

                    }
                    else
                    {
                        InvalidOptions = InvalidOptions + arg + " is an invalid option.\n";
                        ValidOptions = false;
                    }

                }

                if (!ValidOptions)
                {
                    Console.WriteLine("Invalid option(s) specified.");
                    Console.WriteLine(InvalidOptions);
                    Console.WriteLine();
                    DisplayUsage();
                }
                else
                {
                    if (!HelpMode)
                    {
                        RunMode = true;
                    }
                }
            }
            else                        // Display usage instructions
            {
                RunMode = false;
                DisplayUsage();
            }

            if (ExecOption == "AUTO")
            {
                Globals.FullManualMode = false;
                Globals.FullAutoMode = true;
                InteractiveMode = true;
            }
            else if (ExecOption == "FULLAUTO")
            {
                Globals.FullManualMode = false;
                Globals.FullAutoMode = true;
                InteractiveMode = false;
            }
            else if (ExecOption == "MANUAL")
            {
                InteractiveMode = true;
                Globals.FullManualMode = true;
                Globals.FullAutoMode = false;
            }
            else
            {
                Globals.Verbose("ERROR: Invalid ExecOption Specified");
            }


            if (LogOption == "QUIET")
            {
                Globals.VerboseMode = false;
            }
            else if (LogOption == "VERBOSE")
            {
                Globals.VerboseMode = true;
            }
            else
            {
                Globals.Verbose("ERROR: Invalid LogOption Specified");
            }



            while (Generating != "Q" && NewPCs.Count < Iterations  && RunMode)
            {
                cPlayer NewPC = new cPlayer();
                NewPCs.Add(NewPC);

                Console.WriteLine("\n\n******\tNew Character\t******\n\n");
                Console.WriteLine(NewPC.PrintChar());
                Console.WriteLine("\n\n---\t" + "Generated " + NewPCs.Count() + " of " + Iterations + " Characters" + "\t---\n\n");

                if (Globals.FileOutputMode)
                {
                    WriteFile("\n\n******\tNew Character\t******\n\n");
                    WriteFile(NewPC.PrintChar());
                    WriteFile("\n\n---\t" + "Generated " + NewPCs.Count() + " of " + Iterations + " Characters" + "\t---\n\n");
                }

                if (InteractiveMode)
                {
                    Console.Write("Enter Q to Quit, anything else to continue >> ");
                    Generating = Console.ReadLine();
                }
            } // End While Loop

            if (RunMode)
            {
                Console.WriteLine("Characters generated using TravCharGen (Ver 0.7) program by Bob King (2013)");

                Console.WriteLine();
                Console.Write(Disclaimer());
                Console.WriteLine();

                if (Globals.FileOutputMode)
                {
                    WriteFile("Characters generated using TravCharGen (Ver 0.7) program by Bob King (2013)");

                    WriteFile("");
                    WriteFile(Disclaimer());
                }

                foreach (cPlayer ThisPC in NewPCs)
                {
                    Console.WriteLine("\n\n******\t" + ThisPC.FirstName + " " + ThisPC.LastName + "\t******\n\n");
                    Console.WriteLine(ThisPC.PrintChar());
                    Console.WriteLine("\n\n");

                    if (Globals.FileOutputMode)
                    {
                        WriteFile("\n\n******\t" + ThisPC.FirstName + " " + ThisPC.LastName + "\t******\n\n");
                        WriteFile(ThisPC.PrintChar());
                    }

                }

                Console.WriteLine();
                Console.Write(Disclaimer());
                Console.WriteLine();

                if (Globals.FileOutputMode)
                {
                    WriteFile(Disclaimer());
                }                
            }


        } // Main

        static void WriteFile(string text)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Globals.OutputFileName, true))
            {
                file.WriteLine(text);
            }
        }

        static string Disclaimer()
        {
            string result;
            result = "\tThe Traveller game in all forms is owned by Far Future Enterprises.\n";
            result = result + "\tCopyright 1977 - 2013 Far Future Enterprises.\n";
            return result;
        }
        
        static void DisplayUsage()
        {
            Console.WriteLine("\n\tTravCharGen (Ver 0.7) by Bob King. \n\n\tUsage: TravCharGen -R [-N=#] [-M=AUTO/FULLAUTO/MANUAL] [-V=QUIET/VERBOSE] [-O=FILENAME/NONE]");
            Console.WriteLine("\n\t -R : execute the program with default settings");
            Console.WriteLine("\n\t [-N=#] : generate # characters {10} in AUTO/FULL AUTO; {1} in MANUAL");
            Console.WriteLine("\n\t [-M=AUTO/FULLAUTO/MANUAL] : execution mode {AUTO}");
            Console.WriteLine("\n\t [-V=QUIET/VERBOSE] : verbose mode {QUIET}");
            Console.WriteLine("\n\t [-O=FILENAME/NONE] : output filename {TravCharGen.txt}");
            Console.WriteLine("\n\t [-H] : display extended usage instructions");
            Console.WriteLine("\n" + "\tPlease send feedback, bug reports & questions to subbob@gmail.com");
            Console.WriteLine();
            Console.Write(Disclaimer());
        }

        static void DisplayExtendedUsage()
        {
            Console.WriteLine("\n\tTravCharGen (Ver 0.7) by Bob King.\n");
            Console.WriteLine("\tThis program generates characters for the Traveller RPG using methods outlined in Book 1: Characters & Combat.");
            Console.WriteLine("\n\tExtended Usage Instructions:\n");
            Console.WriteLine("\t -R : execute the program with default settings");
            Console.WriteLine("\n\t [-N=#] : generate # characters {20}");
            Console.WriteLine("\n\t [-M=AUTO/FULLAUTO/MANUAL] : execution mode {AUTO}");
            Console.WriteLine("\tAUTO Mode: (Default) All decisions chosen randomly. Each character generated (up to the # characters set with the -n switch) displayed one at at time. After each character, enter Q to quit, or anything else to continue.");
            Console.WriteLine("\tFULLAUTO Mode: As AUTO, except all characters generated with no pause for user interaction.");
            Console.WriteLine("\tMANUAL Mode: Interactive character generation, all choices determined by the user.");
            Console.WriteLine("\n\t [-V=QUIET/VERBOSE] : verbose mode {QUIET}");
            Console.WriteLine("\tQUIET Logging: (Default) No deatiled logging information.");
            Console.WriteLine("\tVERBOSE Logging: Provides detailed logging of all key events. (e.g. Survival rolls, Commmission rolls, etc.) Primarily used for logic debugging, but also included to allow independent verification of consistency with the Book 1 tables. NOTE: All characters generated are printed upon completion to allow clear division of log info & character results.");
            Console.WriteLine("\n\t [-O=FILENAME/NONE] : output filename {TravCharGen.txt}");
            Console.WriteLine("	Output File: Results of each run appended to a text file, in same path as the EXE, as specified by the -o directive. (Default: TravCharGen.txt) Use -o=NONE to disable file output.");
            Console.WriteLine("\n\t [-H] : display extended usage instructions");
            Console.WriteLine("\n\tWhy only Version 0.7? I still need to:");
            Console.WriteLine("\t-- Implement the Mustering Out tables");
            Console.WriteLine("\t-- Add the service automatic skills (e.g. for rank)");
            Console.WriteLine("\t-- Add the checks for stat losses due to age");
            Console.WriteLine("\t-- Finishing the Cascade Skills (Gun Combat, Meleet Combat, etc)");
            Console.WriteLine("\n\tFuture Plans");
            Console.WriteLine("\t-- Adding more error checking to Manual operation mode.");
            Console.WriteLine("\t-- Adding options to specify filter criteria (terms, service, etc) for automatic generation.");
            Console.WriteLine("\t-- Deplying a Forms (GUI) version.");
            Console.WriteLine("\t-- Adding a configuration file for specifying options in lieu of command line switches.");
            Console.WriteLine("\t-- Incorporating the other Classic Traveller books (Mercenary, High Guard, Scouts, Merchants).");
            Console.WriteLine("\n" + "\tPlease send feedback, bug reports & questions to subbob@gmail.com");
            Console.WriteLine();
            Console.Write(Disclaimer());
        }
    } 


}
