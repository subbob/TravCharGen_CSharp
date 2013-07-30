using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class Group : List<string>
    {
        public List<string> GroupList;

        public List<string> GetList()
        {
            return GroupList;
        }

        public Group()
        {
            GroupList = new List<string> {};
        }
        
        // new List<string> { "Gun Combat", "Vehicle", "General", "Melee Combat" };
    }
}
