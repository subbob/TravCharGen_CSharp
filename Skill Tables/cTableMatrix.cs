using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cTableMatrix
    {
        // Public Properties
        private Dictionary<string, cTableRow> Matrix = new Dictionary<string, cTableRow> { };

        // Private Properties

        // Public Methods
        public void Add(string SkillName, int Roll, string RowName, string Service)
        {
            if (!Matrix.ContainsKey(RowName))
            {
                cTableRow temp = new cTableRow();
                Matrix.Add(RowName, temp);
            }
            Matrix[RowName].Add(SkillName,Roll,RowName,Service);
        }

        public string GetTableAsText(string Row, string Service)
        {
            return Matrix[Row].GetRowByText(Service);
        }

        public string GetSkill(int Roll,string RowName, string Service)
        {
            return Matrix[RowName].GetSkill(Roll, Service);
        }

        // Private Methods

        // Default Constructor

    }
}
