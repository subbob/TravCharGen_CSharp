using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class ServicesData
    {
        // Public Properties
        public static List<string> ServiceNames = new List<string> { "Navy", "Marines", "Army", "Scouts", "Merchants", "Other" };

        public NavyServiceData Navy = new NavyServiceData();
        public MarinesServiceData Marines = new MarinesServiceData();
        public ArmyServiceData Army = new ArmyServiceData();
        public ScoutsServiceData Scouts = new ScoutsServiceData();
        public MerchantsServiceData Merchants = new MerchantsServiceData();
        public OtherServiceData Other = new OtherServiceData();
        
        // Private Properties
        private Dictionary<string, cServiceData> ServiceTables = new Dictionary<string, cServiceData> { };

        public bool Enlist(cPlayer PC, string DesiredService)
        {
            return ServiceTables[DesiredService].Enlist(PC);
        }

        public bool Survived(cPlayer PC)
        {
            return ServiceTables[PC.Service].Survived(PC);
        }

        public string RankAsText(cPlayer PC)
        {
            if (PC.Book1Rank > 0)
            {
                return ServiceTables[PC.Service].Ranks[PC.Book1Rank-1];
            }
            else
            {
                return "N/A";
            }
        }

        public bool Commissioned(cPlayer PC)
        {
            return ServiceTables[PC.Service].Commissioned(PC);
        }

        public bool Promoted(cPlayer PC)
        {
            if (PC.Book1Rank > 0)
            {
                return ServiceTables[PC.Service].Promoted(PC);
            }
            else
            {
                return false;
            }
        }

        public bool Reenlisted(cPlayer PC)
        {
            return ServiceTables[PC.Service].Reenlisted(PC);
        }

        private static string RandomService()
        {
            MyLib.Dice Roller = new MyLib.Dice();
            return Globals.ServiceNames.ElementAt(Roller.RollDie(6) - 1);
        }

        public static string Draft()
        {
            string temp;
            temp = RandomService();
            return temp;
        }
        
        // Public Methods

        // Private Methods

        // Default Constructor
        public ServicesData()
        {
            ServiceTables.Add("Navy", Navy);
            ServiceTables.Add("Marines", Marines);
            ServiceTables.Add("Army", Army);
            ServiceTables.Add("Scouts", Scouts);
            ServiceTables.Add("Merchants", Merchants);
            ServiceTables.Add("Other", Other);
        }
    }
}
