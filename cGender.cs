using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traveller_Book1
{
    public class cGender
    {
        private string pGender;

        public static List<string> Genders = new List<string> {"Male","Female"};

        public string Gender()
        {
            return pGender;
        }

        protected void SetGender(string arg_Gender)
        {
            pGender = arg_Gender;
        }
        // Public Properties

        // Private Properties

        // Public Methods

        // Private Methods

        // Default Constructor

    }
}
