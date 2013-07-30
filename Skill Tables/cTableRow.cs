using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cTableRow
    {
        // Public Properties
        private Dictionary<string, cTableElement> Columns = new Dictionary<string, cTableElement> { };
   
        // Private Properties

        // Public Methods
        public string GetSkill(int ID, string Service)
        {
            return Columns[Service].GetSkill(ID);
        }

        public string GetRowByText(string Service)
        {
            string rStr = "";           // Build the return value

            foreach (int Key in Columns[Service].Keys)
            {
                rStr = rStr + GetSkill(Key, Service) + "\n";
            }

            return rStr;
        }

        public void Add(string SkillName, int ID, string RowName, string Service)
        {
            if (!Columns.ContainsKey(Service))
            {
                cTableElement temp = new cTableElement();
                Columns.Add(Service, temp);
            }
            Columns[Service].Add(ID, SkillName);

        }


        // Private Methods

        // Default Constructor

    }
}
