using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cTableElement : Dictionary<int,string>
    {
        public string TableName;
        public string Source;       // Reference source (e.g. Traveller, Book 1)

        public string GetSkill(int ID)
        {
            return this[ID];
        }
    }
}
